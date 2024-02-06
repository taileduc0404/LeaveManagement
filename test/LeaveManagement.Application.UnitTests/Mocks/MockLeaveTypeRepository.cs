using Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using LeaveManagement.Application.Contracts.Persistences;
using LeaveManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.UnitTests.Mocks
{
	public class MockLeaveTypeRepository
	{
		public static Mock<ILeaveTypeRepository> GetMockLeaveTypeRepository()
		{
			var leaveTypes = new List<LeaveType>
			{
				new LeaveType
				{
					Id = 1,
					DefaultDay=10,
					Name="Test Vacation"
				},
				new LeaveType
				{
					Id = 2,
					DefaultDay = 20,
					Name = "Test Sick"
				},
				new LeaveType
				{
					Id = 3,
					DefaultDay = 30,
					Name = "Test Maternity"
				}
			};
			var mockRepo = new Mock<ILeaveTypeRepository>();
			mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(leaveTypes);

			mockRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveType>()))
				.Returns((LeaveType LeaveType) =>
				{
					leaveTypes.Add(LeaveType);
					return Task.CompletedTask;
				});
			return mockRepo;
		}
	}
}
