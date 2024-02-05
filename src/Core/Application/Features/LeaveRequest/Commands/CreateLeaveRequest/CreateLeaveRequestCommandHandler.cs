
using Application.Contracts.Email;
using Application.Contracts.Logging;
using Application.Exceptions;
using Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using Application.Models.Email;
using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;

namespace Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
	public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, Unit>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly IEmailSender _emailSender;
		private readonly IAppLogger<UpdateLeaveRequestCommandHandler> _logger;
		private readonly IMapper _mapper;

		public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,
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

		public async Task<Unit> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateLeaveRequestCommandValidator(_leaveTypeRepository);
			var validationResult = await validator.ValidateAsync(request);
			if (validationResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Leave Request.", validationResult);
			}

			var leaveRequest = _mapper.Map<LeaveManagement.Domain.LeaveRequest>(request);
			await _leaveRequestRepository.CreateAsync(leaveRequest);

			try
			{
				var email = new EmailMessage
				{
					To = string.Empty,
					Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
						$"has been submitted successfully.",
					Subject = "Leave Request Submitted."
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
