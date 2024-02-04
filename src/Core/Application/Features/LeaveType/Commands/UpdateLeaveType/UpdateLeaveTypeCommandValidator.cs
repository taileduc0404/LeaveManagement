using Application.Features.LeaveType.Commands.CreateLeaveType;
using FluentValidation;
using LeaveManagement.Application.Contracts.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveType.Commands.UpdateLeaveType
{
	public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
	{
		private readonly ILeaveTypeRepository _repository;
		public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository repository)
		{
			RuleFor(x => x.Id)
				.NotNull()
				.MustAsync(LeaveTypeMustExist);

			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters.");

			RuleFor(x => x.DefaultDay)
				.LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
				.GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");

			RuleFor(x => x)
				.MustAsync(LeaveTypeNameUnique)
				.WithMessage("LeaveType already exist.");

			_repository = repository;
		}

		private async Task<bool> LeaveTypeMustExist(int id, CancellationToken token)
		{
			var leaveType = await _repository.GetByIdAsync(id);
			return leaveType != null;
		}

		private Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token)
		{
			return _repository.IsLeaveTypeUnique(command.Name);
		}
	}
}
