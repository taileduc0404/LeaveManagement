using Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations
{
	public class LeaveAllocationDto
	{
		public int Id { get; set; }
		public int NumberOfDays { get; set; }
		public LeaveTypesDto? LeaveType { get; set; }
		public int LeaveTypeId { get; set; }
		public int Period { get; set; }
	}
}
