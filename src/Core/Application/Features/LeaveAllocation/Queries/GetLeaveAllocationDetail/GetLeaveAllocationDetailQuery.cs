using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetail
{
	public class GetLeaveAllocationDetailQuery:IRequest<LeaveAllocationDetailDto>
	{
        public int Id { get; set; }
    }
}
