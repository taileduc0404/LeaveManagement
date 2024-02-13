using Microsoft.AspNetCore.Components;
using BlazorUI.Contracts;
using BlazorUI.Models.LeaveTypes;

namespace BlazorUI.Pages.LeaveTypes
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILeaveTypeService LeaveTypeService { get; set; }

        public List<LeaveTypeVM> LeaveTypes { get; private set; }
        public string Message { get; set; } = string.Empty;

        protected void CreateLeaveType()
        {
            NavigationManager.NavigateTo("/leavetypes/create/");
        }

        protected void AllocateLeaveType(int id)
        {
            // Use Leave Allocation Service here
        }

        protected void EditLeaveType(int id)
        {
            NavigationManager.NavigateTo($"/leavetypes/edit/{id}");
        }

        protected void DetailsLeaveType(int id)
        {
            NavigationManager.NavigateTo($"/leavetypes/details/{id}");
        }

        protected async Task DeleteLeaveType(int id)
        {
            var response = await LeaveTypeService.DeleteLeaveType(id);
            if (response.Success)
            {
                LeaveTypes = await LeaveTypeService.GetLeaveTypes(); // Cập nhật danh sách sau khi xóa thành công
                StateHasChanged();
            }
            else
            {
                Message = response.Message;
            }
        }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                LeaveTypes = await LeaveTypeService.GetLeaveTypes();
            }
            catch (Exception ex)
            {
                // Xử lý exception, ví dụ: ghi log, hiển thị thông báo lỗi, vv.
                Message = "Error loading leave types. Please try again later.";
            }
        }

    }
}