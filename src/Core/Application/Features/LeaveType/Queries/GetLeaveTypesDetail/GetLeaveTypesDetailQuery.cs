using MediatR;

namespace Application.Features.LeaveType.Queries.GetAllLeaveTypesDetail
{
	//public class GetLeaveTypeQuery : IRequest<LeaveTypeDto>
	//{
	//}

	public record GetLeaveTypesDetailQuery(int Id) : IRequest<LeaveTypesDetailDto>;
}
