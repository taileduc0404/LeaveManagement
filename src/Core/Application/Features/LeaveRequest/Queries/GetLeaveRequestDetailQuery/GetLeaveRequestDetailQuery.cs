using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequest.Queries.GetLeaveRequestDetailQuery
{
	public class GetLeaveRequestDetailQuery : IRequest<LeaveRequestDetailDto>
	{
		public int Id { get; set; }
	}
}
