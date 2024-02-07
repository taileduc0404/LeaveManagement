using Application.Identity;
using Application.Models.Identity;
using Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services
{
	public class UserService : IUserService
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public UserService(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<Employee> GetEmployee(string userId)
		{
			var employee = await _userManager.FindByIdAsync(userId);
			return new Employee
			{
				Email = employee!.Email,
				FirstName = employee.FirstName,
				LastName = employee.LastName,
				Id = employee.Id
			};
		}

		public async Task<List<Employee>> GetEmployees()
		{
			var employees = await _userManager.GetUsersInRoleAsync("Employee");
			return employees.Select(x => new Employee
			{
				Email = x!.Email,
				FirstName = x.FirstName,
				LastName = x.LastName,
				Id = x.Id
			}).ToList();

		}
	}
}
