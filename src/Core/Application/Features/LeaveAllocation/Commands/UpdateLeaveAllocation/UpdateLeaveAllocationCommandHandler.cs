using Application.Exceptions;
using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation
{
	public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
	{
		private readonly ILeaveAllocationRepository _repository;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository repository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			_repository = repository;
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateLeaveAllocationCommandValidator(_leaveTypeRepository, _repository);
			var validatorResult = await validator.ValidateAsync(request);
			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Leave Allocation", validatorResult);
			}

			var leaveAllocation = await _repository.GetLeaveAllocationWithDetails(request.Id);
			if (leaveAllocation == null)
			{
				throw new NotFoundException(nameof(LeaveAllocation), request.Id);
			}
			_mapper.Map(request, leaveAllocation);
			await _repository.UpdateAsync(leaveAllocation);
			return Unit.Value;
		}
	}
}
