using LeaveManagement.Application.Contracts.Persistences;
using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
	public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
	{
		public LeaveTypeRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<bool> IsLeaveTypeUnique(string name)
		{
			return await _context.leaveTypes.AnyAsync(x => x.Name == name) == false;
		}		
	}
}
