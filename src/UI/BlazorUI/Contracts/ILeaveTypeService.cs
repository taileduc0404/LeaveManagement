using BlazorUI.Models.LeaveTypes;
using BlazorUI.Services.Base;

namespace BlazorUI.Contracts
{
	public interface ILeaveTypeService
	{
		Task<List<LeaveTypeVM>> GetLeaveTypes();
		Task<LeaveTypeVM> GetLeaveTypeDetail(int id);

		Task<Response<Guid>> CreateLeaveType(LeaveTypeVM vm);
		Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVM vm);
		Task<Response<Guid>> DeleteLeaveType(int id, LeaveTypeVM vm);

	}
}
