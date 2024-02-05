using Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetail;
using AutoMapper;
using LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
	public class LeaveAllocationProfile : Profile
	{
		public LeaveAllocationProfile()
		{
			CreateMap<LeaveAllocationDto, LeaveAllocation>().ReverseMap();
			CreateMap<LeaveAllocation, LeaveAllocationDetailDto>();
			CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
			CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
		}
	}
}
