using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;

namespace Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
	public class GetAllLeaveTypeQueryHandler : IRequestHandler<GetAllLeaveTypesQuery, List<LeaveTypesDto>>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _repository;

		public GetAllLeaveTypeQueryHandler(IMapper mapper, ILeaveTypeRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}
		public async Task<List<LeaveTypesDto>> Handle(GetAllLeaveTypesQuery request, CancellationToken cancellationToken)
		{
			//Query the Database
			var leaveTypes = await _repository.GetAsync();

			//Convert data objects to DTO objects
			var data = _mapper.Map<List<LeaveTypesDto>>(leaveTypes);

			//return list of DTO objects
			return data;
		}
	}
}
