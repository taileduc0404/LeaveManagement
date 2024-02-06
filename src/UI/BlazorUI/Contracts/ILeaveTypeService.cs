using BlazorUI.Models.LeaveTypes;
using BlazorUI.Services.Base;

namespace BlazorUI.Contracts
{
	public interface ILeaveTypeService
	{
		Task<List<LeaveTypeVM>> GetLeaveTypes();
		Task<LeaveTypeVM> GetLeaveTypeDetails(int id);
		Task<Response<Guid>> CreateLeaveType(LeaveTypeVM leaveType);
		Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVM leaveType);
		Task<Response<Guid>> DeleteLeaveType(int id);

	}
}
