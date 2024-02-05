using FluentValidation;
using LeaveManagement.Application.Contracts.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
	public class CreateLeaveAllocationCommandValidator : AbstractValidator<CreateLeaveAllocationCommand>
	{
		private readonly ILeaveTypeRepository _repository;

		public CreateLeaveAllocationCommandValidator(ILeaveTypeRepository repository)
		{
			_repository = repository;
			RuleFor(x => x.LeaveTypeId)
				.GreaterThan(0)
				.MustAsync(LeaveTypeMustExist)
				.WithMessage("{PropertyName} does not exist.");
		}

		private async Task<bool> LeaveTypeMustExist(int id, CancellationToken arg2)
		{
			var leaveType = await _repository.GetByIdAsync(id);
			return leaveType != null;

		}
	}
}
