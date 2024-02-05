using Application.Exceptions;
using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
	public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
	{
		private readonly ILeaveAllocationRepository _repository;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository repository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			_repository = repository;
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateLeaveAllocationCommandValidator(_leaveTypeRepository);
			var validationResult = await validator.ValidateAsync(request);
			if (validationResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Leave Allocation Request.", validationResult);
			}

			//get leaveType for allocations
			var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);


			//assign allocations
			var leaveAllocation = _mapper.Map<LeaveManagement.Domain.LeaveAllocation>(request);

			await _repository.CreateAsync(leaveAllocation);
			return Unit.Value;
		}
	}
}
