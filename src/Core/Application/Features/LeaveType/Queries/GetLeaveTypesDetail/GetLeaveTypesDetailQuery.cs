using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveType.Queries.GetAllLeaveTypesDetail
{
	//public class GetLeaveTypeQuery : IRequest<LeaveTypeDto>
	//{
	//}

	public record GetLeaveTypesDetailQuery(int Id) : IRequest<LeaveTypesDetailDto>;
}
