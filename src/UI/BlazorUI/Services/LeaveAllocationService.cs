using Blazored.LocalStorage;
using BlazorUI.Contracts;
using BlazorUI.Services.Base;

namespace BlazorUI.Services
{
	public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
	{
		public LeaveAllocationService(IClient client, ILocalStorageService localStorageService) : base(client, localStorageService)
		{
		}
	}
}
