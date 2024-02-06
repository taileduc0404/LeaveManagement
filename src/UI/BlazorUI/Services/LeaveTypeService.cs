using BlazorUI.Contracts;
using BlazorUI.Services.Base;

namespace BlazorUI.Services
{
	public class LeaveTypeService : BaseHttpService, ILeaveTypeService
	{
		public LeaveTypeService(IClient client) : base(client)
		{
		}
	}
}
