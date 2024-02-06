using Application.Contracts.Logging;
using Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using Application.MappingProfiles;
using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace LeaveManagement.Application.UnitTests.Features.LeaveTypes.Queries
{
	public class GetLeaveTypeListQueryHadlerTests
	{
		private readonly Mock<ILeaveTypeRepository> _mockRepo;
		private IMapper _mapper;
		private Mock<IAppLogger<GetAllLeaveTypeQueryHandler>> _mockAppLogger;
		public GetLeaveTypeListQueryHadlerTests()
		{
			_mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

			var mapperConfig = new MapperConfiguration(c =>
			{
				c.AddProfile<LeaveTypeProfile>();
			});
			_mapper = mapperConfig.CreateMapper();
			_mockAppLogger = new Mock<IAppLogger<GetAllLeaveTypeQueryHandler>>();
		}

		[Fact]
		public async Task GetLeaveTypeListTest()
		{
			var handler = new GetAllLeaveTypeQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);
			var result = await handler.Handle(new GetAllLeaveTypesQuery(), CancellationToken.None);
			result.ShouldBeOfType<List<LeaveTypesDto>>();
			result.Count.ShouldBe(3);

		}
	}

	//public class GetLeaveTypeListQueryHandlerTests
	//{
	//	private readonly Mock<ILeaveTypeRepository> _mockRepo;
	//	private IMapper _mapper;
	//	private Mock<IAppLogger<GetAllLeaveTypeQueryHandler>> _mockAppLogger;

	//	public GetLeaveTypeListQueryHandlerTests()
	//	{
	//		_mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

	//		var mapperConfig = new MapperConfiguration(c =>
	//		{
	//			c.AddProfile<LeaveTypeProfile>();
	//		});

	//		_mapper = mapperConfig.CreateMapper();
	//		_mockAppLogger = new Mock<IAppLogger<GetAllLeaveTypeQueryHandler>>();
	//	}

	//	[Fact]
	//	public async Task GetLeaveTypeListTest()
	//	{
	//		var handler = new GetAllLeaveTypeQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

	//		var result = await handler.Handle(new GetAllLeaveTypesQuery(), CancellationToken.None);

	//		result.ShouldBeOfType<List<LeaveTypesDto>>();
	//		result.Count.ShouldBe(3);
	//	}
	//}
}
