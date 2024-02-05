using Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequest.Queries.GetLeaveRequestDetailQuery
{
	public class LeaveRequestDetailDto
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string? RequestEmployeeId { get; set; }
		public LeaveTypesDto? LeaveType { get; set; }
		public int LeaveTypeId { get; set; }
		public DateTime DateRequested { get; set; }
        public string? RequestComments { get; set; }
        public DateTime? DateActioned { get; set; }
		public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
	}
}
