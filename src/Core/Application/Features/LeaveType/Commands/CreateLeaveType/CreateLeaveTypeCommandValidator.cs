using FluentValidation;
using LeaveManagement.Application.Contracts.Persistences;

namespace Application.Features.LeaveType.Commands.CreateLeaveType
{
	public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
	{
		private readonly ILeaveTypeRepository _repository;
		public CreateLeaveTypeCommandValidator(ILeaveTypeRepository repository)
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters.");

			RuleFor(x => x.DefaultDay)
				.LessThan(365).WithMessage("{PropertyName} cannot exceed 100")
				.GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");

			RuleFor(x => x)
				.MustAsync(LeaveTypeNameUnique)
				.WithMessage("LeaveType already exist.");

			_repository = repository;
		}


		private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
		{
			return _repository.IsLeaveTypeUnique(command.Name);
		}
	}
}
