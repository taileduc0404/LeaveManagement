using Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Email
{
	public interface IEmailSender
	{
		Task<bool> SendMail(EmailMessage email);
	}
}
