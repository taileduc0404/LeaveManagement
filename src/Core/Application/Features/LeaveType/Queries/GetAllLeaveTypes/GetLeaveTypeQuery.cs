﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
	//public class GetLeaveTypeQuery : IRequest<LeaveTypeDto>
	//{
	//}

	public record GetAllLeaveTypesDetailQuery : IRequest<List<LeaveTypesDetailDto>>;
}
