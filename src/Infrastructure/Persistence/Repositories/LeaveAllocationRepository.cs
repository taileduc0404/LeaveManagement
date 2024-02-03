using LeaveManagement.Application.Contracts.Persistences;
using LeaveManagement.Domain;
using Persistence.Context;

namespace Persistence.Repositories
{
	public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
	{
		public LeaveAllocationRepository(ApplicationDbContext context) : base(context)
		{
		}

		public Task AddAllocation(List<LeaveAllocation> leaveAllocations)
		{
			throw new NotImplementedException();
		}

		public Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
		{
			throw new NotImplementedException();
		}

		public Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
		{
			throw new NotImplementedException();
		}

		public Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
		{
			throw new NotImplementedException();
		}

		public Task<LeaveAllocation> GetUserAllocation(string userId, int leaveTypeId)
		{
			throw new NotImplementedException();
		}
	}
}
