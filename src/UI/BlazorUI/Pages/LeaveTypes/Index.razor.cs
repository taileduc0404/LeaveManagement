using Microsoft.AspNetCore.Components;
using BlazorUI.Contracts;
using BlazorUI.Models.LeaveTypes;

namespace BlazorUI.Pages.LeaveTypes
{
	public partial class Index
	{
		[Inject]
		public NavigationManager? NavigationManager { get; set; }

		[Inject]
		public ILeaveTypeService? LeaveTypeService { get; set; }
		[Inject]
		public ILeaveAllocationService? LeaveAllocationService { get; set; }
		public List<LeaveTypeVM>? LeaveTypes { get; private set; }
		public string Message { get; set; } = string.Empty;
		protected void CreateLeaveType()
		{
			NavigationManager!.NavigateTo("/leavetypes/create/");
		}

		protected void AllocationLeaveType(int id)
		{
			// Use Leave Allocation Service Here
		}

		protected void EditLeaveType(int id)
		{
			NavigationManager!.NavigateTo("/leavetypes/edit/{id}");
		}

		protected void DetailLeaveType(int id)
		{
			NavigationManager!.NavigateTo("/leavetypes/detail/{id}");
		}

		protected async Task DeleteLeaveType(int id)
		{
			var response = await LeaveTypeService!.DeleteLeaveType(id);
			if (response.Success)
			{
				StateHasChanged();
			}
			else
			{
				Message = response.Message!;
			}
		}
		protected override async Task OnInitializedAsync()
		{
			LeaveTypes = await LeaveTypeService!.GetLeaveTypes();
		}

	}
}