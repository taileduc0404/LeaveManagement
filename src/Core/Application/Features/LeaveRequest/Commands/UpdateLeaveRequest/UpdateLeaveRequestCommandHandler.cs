﻿using Application.Contracts.Email;
using Application.Contracts.Logging;
using Application.Exceptions;
using Application.Models.Email;
using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequest.Commands.UpdateLeaveRequest
{
	public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly IEmailSender _emailSender;
		private readonly IAppLogger<UpdateLeaveRequestCommandHandler> _logger;
		private readonly IMapper _mapper;

		public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,
			IMapper mapper,
			ILeaveTypeRepository leaveTypeRepository,
			IEmailSender emailSender,
			IAppLogger<UpdateLeaveRequestCommandHandler> logger)
		{
			_leaveTypeRepository = leaveTypeRepository;
			_leaveRequestRepository = leaveRequestRepository;
			_emailSender = emailSender;
			this._logger = logger;
			this._mapper = mapper;
		}

		public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
		{
			var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
			if (leaveRequest == null)
			{
				throw new NotFoundException(nameof(LeaveRequest), request.Id);
			}

			var validator = new UpdateLeaveRequestCommandValidator(_leaveTypeRepository, _leaveRequestRepository);
			var validationResult = await validator.ValidateAsync(request);
			if (validationResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Leave Request.", validationResult);
			}

			_mapper.Map(request, leaveRequest);
			await _leaveRequestRepository.UpdateAsync(leaveRequest);


			//send confirmation email
			try
			{
				var email = new EmailMessage
				{
					To = string.Empty,
					Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
						$"has been updated successfully.",
					Subject = "Leave request Updated."
				};
				await _emailSender.SendMail(email);
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message);
			}
			

			return Unit.Value;
		}
	}
}
