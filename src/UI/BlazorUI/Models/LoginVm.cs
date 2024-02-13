using System.ComponentModel.DataAnnotations;

namespace BlazorUI.Models
{
	public class LoginVm
	{
		[Required]
		public string Email { get; set; } = string.Empty;
		[Required]
		public string Password { get; set; } = string.Empty;
	}
}
