using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
	public class GetLeaveTypeQueryHandler : IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDto>>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _repository;

		public GetLeaveTypeQueryHandler(IMapper mapper, ILeaveTypeRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}
		public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
		{
			//Query the Database
			var leaveTypes = await _repository.GetAsync();

			//Convert data objects to DTO objects
			var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

			//return list of DTO objects
			return data;
		}
	}
}
