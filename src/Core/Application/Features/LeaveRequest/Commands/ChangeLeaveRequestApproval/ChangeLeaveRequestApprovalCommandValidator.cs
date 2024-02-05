using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval
{
	public class ChangeLeaveRequestApprovalCommandValidator:AbstractValidator<ChangeLeaveRequestApprovalCommand>
	{
        public ChangeLeaveRequestApprovalCommandValidator()
        {
            RuleFor(x => x.Approved)
                .NotNull()
                .WithMessage("Approved status cannot be null");
        }
    }
}
