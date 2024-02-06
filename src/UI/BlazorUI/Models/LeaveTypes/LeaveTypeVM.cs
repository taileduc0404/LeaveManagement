using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorUI.Models.LeaveTypes
{
	public class LeaveTypeVM
	{
		public string Id { get; set; }
		[Required]
		public string? Name { get; set; }
		[Required]
		[Display(Name = "Default Number Of Days")]
		public string? DefaultDays { get; set; }
	}
}
