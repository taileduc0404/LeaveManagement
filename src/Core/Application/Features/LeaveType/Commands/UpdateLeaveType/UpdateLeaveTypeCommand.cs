using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveType.Commands.UpdateLeaveType
{
	public class UpdateLeaveTypeCommand : IRequest<Unit>
	{
		public string Name { get; set; } = string.Empty;
		public string DefaultDay { get; set; } = string.Empty;
	}
}
