using Application.Contracts.Logging;
using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations
{
	public class GetAllLeaveAllocationsQueryHandler : IRequestHandler<GetAllLeaveAllocationsQuery, List<LeaveAllocationDto>>
	{
		private readonly ILeaveAllocationRepository _repository;
		private readonly IMapper _mapper;

		public GetAllLeaveAllocationsQueryHandler(ILeaveAllocationRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<List<LeaveAllocationDto>> Handle(GetAllLeaveAllocationsQuery request, CancellationToken cancellationToken)
		{
			var leaveAllocation = await _repository.GetLeaveAllocationWithDetails();
			var allocation = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocation);
			return allocation;
		}
	}
}
