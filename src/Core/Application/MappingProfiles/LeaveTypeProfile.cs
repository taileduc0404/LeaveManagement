using Application.Features.LeaveType.Queries.GetAllLeaveTypes;
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
			CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
		}
	}
}
