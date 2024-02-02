using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Contracts.Persistences
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T> GetAsync();
		Task<T> GetByIdAsync(int id);
		Task<T> CreateAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task<T> DeleteAsync(T entity);
	}
}
