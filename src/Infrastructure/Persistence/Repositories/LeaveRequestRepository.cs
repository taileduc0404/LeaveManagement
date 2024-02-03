using LeaveManagement.Application.Contracts.Persistences;
using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Security.Cryptography.X509Certificates;

namespace Persistence.Repositories
{
	public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
	{
		public LeaveRequestRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
		{
			var leaveRequest = await _context.leaveRequests
				.Include(x => x.LeaveType)
				.FirstOrDefaultAsync(x => x.Id == id);
			return leaveRequest!;
		}

		public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
		{
			var leaveRequests = await _context.leaveRequests
				.Include(x => x.LeaveType)
				.ToListAsync();
			return leaveRequests;
		}

		public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
		{
			var leaveRequests = await _context.leaveRequests
				.Where(x => x.RequestingEmployeeId == userId)
				.Include(x => x.LeaveType)
				.ToListAsync();
			return leaveRequests;

		}
	}
}
