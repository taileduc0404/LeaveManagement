﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequest.Commands.DeleteLeaveRequest
{
	public class DeleteLeaveRequestCommand : IRequest
	{
		public int Id { get; set; }
	}
}
