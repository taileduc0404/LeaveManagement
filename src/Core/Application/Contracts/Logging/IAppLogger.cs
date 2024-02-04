using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Logging
{
	public interface IAppLogger<T>
	{
		void LogInfomation(string message, params object[] args);
		void LogWarning(string message, params object[] args);


	}
}
