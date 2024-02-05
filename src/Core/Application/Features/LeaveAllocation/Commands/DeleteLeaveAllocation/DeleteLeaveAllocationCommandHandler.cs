using Application.Exceptions;
using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation
{
	public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
	{
		private readonly ILeaveAllocationRepository _repository;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository repository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			_repository = repository;
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
		{
			var leaveAllocation = await _repository.GetLeaveAllocationWithDetails(request.Id) ?? throw new NotFoundException(nameof(LeaveAllocation), request.Id);

			await _repository.DeleteAsync(leaveAllocation);
			return Unit.Value;
		}
	}
}
