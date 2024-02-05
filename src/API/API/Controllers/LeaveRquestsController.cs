﻿using Application.Features.LeaveRequest.Commands.CancelLeaveRequest;
using Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;
using Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;
using Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using Application.Features.LeaveRequest.Queries.GetAllLeaveRequestQuery;
using Application.Features.LeaveRequest.Queries.GetLeaveRequestDetailQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LeaveRquestsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LeaveRquestsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// GET: api/<LeaveRequestsController>
		[HttpGet]
		public async Task<ActionResult<List<LeaveRequestDto>>> Get(bool isLoggedInUser = false)
		{
			var leaveRequests = await _mediator.Send(new GetAllLeaveRequestQuery());
			return Ok(leaveRequests);
		}

		// GET api/<LeaveRequestsController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<LeaveRequestDetailDto>> Get(int id)
		{
			var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailQuery { Id = id });
			return Ok(leaveRequest);
		}

		// POST api/<LeaveRequestsController>
		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> Post()
		{
			var response = await _mediator.Send(new CreateLeaveRequestCommand());
			return CreatedAtAction(nameof(Get), new { id = response });
		}

		// PUT api/<LeaveRequestsController>/5
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Put(UpdateLeaveRequestCommand leaveRequest)
		{
			await _mediator.Send(leaveRequest);
			return NoContent();
		}

		// PUT api/<LeaveRequestsController>/CancelRequest/
		[HttpPut]
		[Route("CancelRequest")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> CancelRequest(CancelLeaveRequestCommand cancelLeaveRequest)
		{
			await _mediator.Send(cancelLeaveRequest);
			return NoContent();
		}

		// PUT api/<LeaveRequestsController>/UpdateApproval/
		[HttpPut]
		[Route("UpdateApproval")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> UpdateApproval(ChangeLeaveRequestApprovalCommand updateApprovalRequest)
		{
			await _mediator.Send(updateApprovalRequest);
			return NoContent();
		}

		// DELETE api/<LeaveRequestsController>/5
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Delete(int id)
		{
			var command = new DeleteLeaveRequestCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
