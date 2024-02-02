using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveType.Queries.GetAllLeaveTypesDetail
{
	public class LeaveTypesDetailDto
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
		public string DefaultDay { get; set; } = string.Empty;
		public DateTime? DateCreated { get; set; }
		public DateTime? DateModified { get; set; }
	}
}
