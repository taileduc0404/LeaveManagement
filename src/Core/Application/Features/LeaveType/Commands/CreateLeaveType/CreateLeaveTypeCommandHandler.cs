using Application.Exceptions;
using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;

namespace Application.Features.LeaveType.Commands.CreateLeaveType
{
	public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
	{
		private readonly ILeaveTypeRepository _repository;

		private readonly IMapper _mapper;
		public CreateLeaveTypeCommandHandler(ILeaveTypeRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}


		public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			//validate incoming data
			var validator = new CreateLeaveTypeCommandValidator(_repository);
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Any())
			{
				throw new BadRequestException("Invalid LeaveType.", validationResult);
			}
			//convert to domain entity object
			var leaveTypeToCreate = _mapper.Map<LeaveManagement.Domain.LeaveType>(request);

			//add to database
			await _repository.CreateAsync(leaveTypeToCreate);

			//return
			return leaveTypeToCreate.Id;

			//// Validate incoming data
			//var validator = new CreateLeaveTypeCommandValidator(_repository);
			//var validationResult = await validator.ValidateAsync(request);

			//if (validationResult.Errors.Any())
			//	throw new BadRequestException("Invalid Leave type", validationResult);

			//// convert to domain entity object
			//var leaveTypeToCreate = _mapper.Map<LeaveManagement.Domain.LeaveType>(request);

			//// add to database
			//await _repository.CreateAsync(leaveTypeToCreate);

			//// retun record id
			//return leaveTypeToCreate.Id;
		}
	}
}
