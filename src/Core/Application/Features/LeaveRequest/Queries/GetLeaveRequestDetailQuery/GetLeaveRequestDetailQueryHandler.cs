using Application.Exceptions;
using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequest.Queries.GetLeaveRequestDetailQuery
{
	public class GetLeaveRequestDetailQueryHandler : IRequestHandler<GetLeaveRequestDetailQuery, LeaveRequestDetailDto>
	{
		private readonly ILeaveRequestRepository _repository;
		private readonly IMapper _mapper;

		public GetLeaveRequestDetailQueryHandler(ILeaveRequestRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<LeaveRequestDetailDto> Handle(GetLeaveRequestDetailQuery request, CancellationToken cancellationToken)
		{
			var leaveRequest = await _repository.GetLeaveRequestWithDetails(request.Id);
			if (leaveRequest == null)
			{
				throw new NotFoundException(nameof(LeaveRequest), request.Id);
			}


			return _mapper.Map<LeaveRequestDetailDto>(request);
		}
	}
}
