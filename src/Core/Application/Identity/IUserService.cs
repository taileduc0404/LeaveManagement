using Application.Models.Identity;

namespace Application.Identity
{
	public interface IUserService
	{
		Task<List<Employee>> GetEmployees();
		Task<Employee> GetEmployee(string userId);
	}
}
