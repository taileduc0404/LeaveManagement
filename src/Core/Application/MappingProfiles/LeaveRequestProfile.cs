using Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using Application.Features.LeaveRequest.Queries.GetAllLeaveRequestQuery;
using Application.Features.LeaveRequest.Queries.GetLeaveRequestDetailQuery;
using AutoMapper;
using LeaveManagement.Domain;

namespace Application.MappingProfiles
{
	public class LeaveRequestProfile : Profile
	{
		public LeaveRequestProfile()
		{
			CreateMap<LeaveRequestDto, LeaveRequest>().ReverseMap();
			CreateMap<LeaveRequest, LeaveRequestDetailDto>();
			CreateMap<CreateLeaveRequestCommand, LeaveRequest>();
			CreateMap<UpdateLeaveRequestCommand, LeaveRequest>();
		}
	}
}
