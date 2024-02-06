using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Shouldly;

namespace LeaveManagement.Persistence.IntergrationTests
{
	public class ApplicationDbContextTests
	{
		private readonly ApplicationDbContext _applicationDbContext;

		public ApplicationDbContextTests()
		{
			var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

			_applicationDbContext = new ApplicationDbContext(dbOptions);
		}

		[Fact]
		public async void Save_SetDateCreatedValue()
		{
			// Arrange
			var leaveType = new LeaveType
			{
				Id = 1,
				DefaultDay = 10,
				Name = "Test Vacation"
			};

			// Act
			await _applicationDbContext.leaveTypes.AddAsync(leaveType);
			await _applicationDbContext.SaveChangesAsync();

			//Assert
			leaveType.DateCreated.ShouldNotBeNull();

		}

		[Fact]
		public async void Save_SetDateModifiedValue()
		{
			// Arrange
			var leaveType = new LeaveType
			{
				Id = 1,
				DefaultDay = 10,
				Name = "Test Vacation"
			};

			// Act
			await _applicationDbContext.leaveTypes.AddAsync(leaveType);
			await _applicationDbContext.SaveChangesAsync();

			//Assert
			leaveType.DateModified.ShouldNotBeNull();
		}
	}
}