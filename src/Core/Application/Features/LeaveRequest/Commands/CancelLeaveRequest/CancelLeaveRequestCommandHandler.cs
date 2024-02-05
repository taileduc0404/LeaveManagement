using Application.Contracts.Email;
using Application.Exceptions;
using Application.Models.Email;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequest.Commands.CancelLeaveRequest
{
	public class CancelLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand, Unit>
	{
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly IEmailSender _emailSender;

		public CancelLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IEmailSender emailSender)
		{
			_leaveRequestRepository = leaveRequestRepository;
			_emailSender = emailSender;
		}

		public async Task<Unit> Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
		{
			var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
			if (leaveRequest == null)
			{
				throw new NotFoundException(nameof(LeaveRequest), request.Id);
			}
			leaveRequest.Cancled = true;
			var email = new EmailMessage
			{
				To = string.Empty,
				Body = $"Your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} " +
						$"has been canceled successfully.",
				Subject = "Leave Request Canceled."
			};
			await _emailSender.SendMail(email);

			return Unit.Value;
		}
	}
}
