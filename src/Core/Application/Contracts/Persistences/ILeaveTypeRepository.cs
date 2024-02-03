using LeaveManagement.Domain;

namespace LeaveManagement.Application.Contracts.Persistences
{
	public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
	{
		Task<bool> IsLeaveTypeUnique(string name);
	}
}
