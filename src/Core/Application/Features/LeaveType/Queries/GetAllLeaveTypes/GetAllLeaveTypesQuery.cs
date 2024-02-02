using MediatR;

namespace Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
	//public class GetLeaveTypeQuery : IRequest<LeaveTypeDto>
	//{
	//}

	public record GetAllLeaveTypesQuery : IRequest<List<LeaveTypesDto>>;
}
