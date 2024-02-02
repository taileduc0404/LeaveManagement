
namespace Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
	public class LeaveTypesDto
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
		public string DefaultDay { get; set; } = string.Empty;
	}
}
