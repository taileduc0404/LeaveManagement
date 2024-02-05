using Application.Exceptions;
using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetail
{
	public class GetLeaveAllocationDetailQueryHandler : IRequestHandler<GetLeaveAllocationDetailQuery, LeaveAllocationDetailDto>
	{
		private readonly ILeaveAllocationRepository _repository;
		private readonly IMapper _mapper;

		public GetLeaveAllocationDetailQueryHandler(ILeaveAllocationRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<LeaveAllocationDetailDto> Handle(GetLeaveAllocationDetailQuery request, CancellationToken cancellationToken)
		{
			var leaveAllocation = await _repository.GetLeaveAllocationWithDetails(request.Id);
			if (leaveAllocation == null)
			{
				throw new NotFoundException(nameof(LeaveAllocation), request.Id);
			}
			var leaveAllocationMapper = _mapper.Map<LeaveAllocationDetailDto>(leaveAllocation);
			return leaveAllocationMapper;
		}
	}
}
