using Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequest.Queries.GetAllLeaveRequestQuery
{
	public class LeaveRequestDto
	{
		public string? RequestEmployeeId { get; set; }
		public LeaveTypesDto? LeaveType { get; set; }
		public DateTime DateRequested { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public bool? Approved { get; set; }
	}
}
