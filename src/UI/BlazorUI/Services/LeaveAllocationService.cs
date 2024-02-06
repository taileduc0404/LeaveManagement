using BlazorUI.Contracts;
using BlazorUI.Services.Base;

namespace BlazorUI.Services
{
	public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
	{
		public LeaveAllocationService(IClient client) : base(client)
		{
		}
	}
}
