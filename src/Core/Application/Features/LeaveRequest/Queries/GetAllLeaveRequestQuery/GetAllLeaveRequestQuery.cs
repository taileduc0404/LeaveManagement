using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequest.Queries.GetAllLeaveRequestQuery
{
	public class GetAllLeaveRequestQuery : IRequest<List<LeaveRequestDto>>
	{
	}
}
