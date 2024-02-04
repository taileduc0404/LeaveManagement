using Application.Features.LeaveType.Commands.CreateLeaveType;
using Application.Features.LeaveType.Commands.UpdateLeaveType;
using Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using Application.Features.LeaveType.Queries.GetAllLeaveTypesDetail;
using AutoMapper;
using LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
	public class LeaveTypeProfile : Profile
	{
		public LeaveTypeProfile()
		{
			CreateMap<LeaveTypesDto, LeaveType>().ReverseMap();
			CreateMap<LeaveType, LeaveTypesDetailDto>();
			CreateMap<CreateLeaveTypeCommand, LeaveType>();
			CreateMap<UpdateLeaveTypeCommand, LeaveType>();
		}
	}
}
