using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequest.Queries.GetAllLeaveRequestQuery
{
	public class GetAllLeaveRequestQueryHandler : IRequestHandler<GetAllLeaveRequestQuery, List<LeaveRequestDto>>
	{
		private readonly ILeaveRequestRepository _repository;
		private readonly IMapper _mapper;

		public GetAllLeaveRequestQueryHandler(ILeaveRequestRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<List<LeaveRequestDto>> Handle(GetAllLeaveRequestQuery request, CancellationToken cancellationToken)
		{
			var leaveRequest = await _repository.GetAsync();
			return _mapper.Map<List<LeaveRequestDto>>(leaveRequest);

		}
	}
}
