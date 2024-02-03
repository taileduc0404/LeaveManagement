using LeaveManagement.Application.Contracts.Persistences;
using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
	public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
	{
		public LeaveAllocationRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task AddAllocation(List<LeaveAllocation> leaveAllocations)
		{
			await _context.AddRangeAsync(leaveAllocations);
		}

		public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
		{
			return await _context.leaveAllocations
				.AnyAsync(x => x.LeaveTypeId == leaveTypeId && x.EmployeeId == userId && x.Period == period);
		}

		public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
		{
			var leaveAllocation = await _context.leaveAllocations
				.Include(x => x.LeaveType)
				.FirstOrDefaultAsync(x => x.Id == id);
			return leaveAllocation!;
		}

		public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
		{
			var leaveAllocations = await _context.leaveAllocations
				.Include(x => x.LeaveType)
				.ToListAsync();
			return leaveAllocations;
		}

		public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
		{
			var leaveAllocations = await _context.leaveAllocations
				.Where(x => x.EmployeeId == userId)
				.Include(x => x.LeaveType)
				.ToListAsync();
			return leaveAllocations;
		}

		public async Task<LeaveAllocation> GetUserAllocation(string userId, int leaveTypeId)
		{
			var leaveAllocation = await _context.leaveAllocations
				.FirstOrDefaultAsync(x => x.EmployeeId == userId && x.LeaveTypeId == leaveTypeId);

			return leaveAllocation!;
		}
	}
}
