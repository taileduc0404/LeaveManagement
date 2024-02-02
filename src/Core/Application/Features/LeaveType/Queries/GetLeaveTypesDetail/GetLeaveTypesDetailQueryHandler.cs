
using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;

namespace Application.Features.LeaveType.Queries.GetAllLeaveTypesDetail
{
	public class GetLeaveTypesDetailQueryHandler : IRequestHandler<GetLeaveTypesDetailQuery, LeaveTypesDetailDto>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _repository;

		public GetLeaveTypesDetailQueryHandler(IMapper mapper, ILeaveTypeRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}
		public async Task<LeaveTypesDetailDto> Handle(GetLeaveTypesDetailQuery request, CancellationToken cancellationToken)
		{
			//Query the Database
			var leaveTypes = await _repository.GetByIdAsync(request.Id);

			//Convert data objects to DTO objects
			var data = _mapper.Map<LeaveTypesDetailDto>(leaveTypes);

			//return list of DTO objects
			return data;
		}
	}
}
