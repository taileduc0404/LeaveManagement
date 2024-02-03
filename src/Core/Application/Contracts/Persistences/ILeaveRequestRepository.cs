using LeaveManagement.Domain;

namespace LeaveManagement.Application.Contracts.Persistences
{
	public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
	{
		Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
		Task<List<LeaveRequest>> GetLeaveRequestWithDetails();
		Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId);

	}
}
