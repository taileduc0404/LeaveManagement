using LeaveManagement.Domain;
using LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<LeaveType> leaveTypes { get; set; }
		public DbSet<LeaveAllocation> leaveAllocations { get; set; }
		public DbSet<LeaveRequest> leaveRequests { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

			base.OnModelCreating(modelBuilder);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
				.Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
			{
				entry.Entity.DateModified = DateTime.Now;
				if (entry.State == EntityState.Added)
				{
					entry.Entity.DateCreated = DateTime.Now;
				}

			}
			return base.SaveChangesAsync(cancellationToken);
		}
	}
}
