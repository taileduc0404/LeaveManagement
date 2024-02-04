using MediatR;

namespace Application.Features.LeaveType.Commands.CreateLeaveType
{
	public class CreateLeaveTypeCommand : IRequest<int>
	{
		public string Name { get; set; } = string.Empty;
		public int DefaultDay { get; set; }
	}
}
