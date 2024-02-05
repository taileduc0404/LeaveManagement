using Application.Contracts.Email;
using Application.Contracts.Logging;
using Application.Exceptions;
using Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using Application.Models.Email;
using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval
{
	public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly IEmailSender _emailSender;
		private readonly IMapper _mapper;

		public ChangeLeaveRequestApprovalCommandHandler(ILeaveRequestRepository leaveRequestRepository,
			IMapper mapper,
			ILeaveTypeRepository leaveTypeRepository,
			IEmailSender emailSender)
		{
			_leaveTypeRepository = leaveTypeRepository;
			_leaveRequestRepository = leaveRequestRepository;
			_emailSender = emailSender;
			this._mapper = mapper;
		}

		public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
		{
			var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
			if (leaveRequest == null)
			{
				throw new NotFoundException(nameof(LeaveRequest), request.Id);
			}

			leaveRequest.Approved = request.Approved;

			var email = new EmailMessage
			{
				To = string.Empty,
				Body = $"The approval status for your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} " +
						$"has been updated.",
				Subject = "Leave Request Approval Status Udpated."
			};
			await _emailSender.SendMail(email);
			return Unit.Value;
		}
	}
}
