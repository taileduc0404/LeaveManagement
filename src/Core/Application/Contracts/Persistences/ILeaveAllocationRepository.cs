using LeaveManagement.Domain;

namespace LeaveManagement.Application.Contracts.Persistences
{
	public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
	{
		Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
		Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails();
		Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId);
		Task<bool> AllocationExists(string userId, int leaveTypeId, int period);
		Task AddAllocation(List<LeaveAllocation> leaveAllocations);
		Task<LeaveAllocation> GetUserAllocation(string userId, int leaveTypeId);

	}
}
