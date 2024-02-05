using FluentValidation;
using LeaveManagement.Application.Contracts.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation
{
	public class UpdateLeaveAllocationCommandValidator : AbstractValidator<UpdateLeaveAllocationCommand>
	{
		private readonly ILeaveTypeRepository _repository;
		private readonly ILeaveAllocationRepository _leaveAllocationRepository;

		public UpdateLeaveAllocationCommandValidator(ILeaveTypeRepository repository,
			ILeaveAllocationRepository leaveAllocationRepository)
		{
			_repository = repository;
			_leaveAllocationRepository = leaveAllocationRepository;
			RuleFor(x => x.NumberOfDays)
				.GreaterThan(0)
				.WithMessage("{PropertyName} must greater than {ComparisonValue}");

			RuleFor(x => x.Period)
				.GreaterThanOrEqualTo(DateTime.Now.Year)
				.WithMessage("{PropertyName} must be after {ComparisonValue}");

			RuleFor(x => x.LeaveTypeId)
				.GreaterThan(0)
				.MustAsync(LeaveTypeMustExist)
				.WithMessage("{PropertyName} does not exist.");

			RuleFor(x => x.Id)
				.NotNull()
				.MustAsync(LeaveAllocationMustExist)
				.WithMessage("{PropertyName} must be present");
		}

		private async Task<bool> LeaveAllocationMustExist(int id, CancellationToken arg2)
		{
			var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(id);
			return leaveAllocation != null;
		}

		private async Task<bool> LeaveTypeMustExist(int id, CancellationToken arg2)
		{
			var leaveType = await _repository.GetByIdAsync(id);
			return leaveType != null;
		}
	}
}
