using AutoMapper;
using BlazorUI.Models.LeaveTypes;
using BlazorUI.Services.Base;

namespace BlazorUI.MappingProfiles
{
	public class MappingConfig : Profile
	{
		public MappingConfig()
		{
			CreateMap<LeaveTypesDto, LeaveTypeVM>().ReverseMap();
			//CreateMap<LeaveTypeVM, CreateLeaveTypeCommand>();
			CreateMap<CreateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
			CreateMap<UpdateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();


		}
	}
}
