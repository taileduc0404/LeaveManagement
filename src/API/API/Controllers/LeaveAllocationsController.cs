using Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetail;
using Application.Features.LeaveType.Commands.CreateLeaveType;
using Application.Features.LeaveType.Commands.DeleteLeaveType;
using Application.Features.LeaveType.Commands.UpdateLeaveType;
using Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using Application.Features.LeaveType.Queries.GetAllLeaveTypesDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LeaveAllocationsController : ControllerBase
	{
		private readonly IMediator _mediator;
		public LeaveAllocationsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		// GET: api/<LeaveTypesController>
		[HttpGet]
		public async Task<List<LeaveAllocationDto>> Get(bool isLoggedInUser = false)
		{
			var leaveAllocation = await _mediator.Send(new GetAllLeaveAllocationsQuery());
			return leaveAllocation;
		}

		// GET api/<LeaveTypesController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<LeaveAllocationDetailDto>> Get(int id)
		{
			var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailQuery { Id = id });
			return Ok(leaveAllocation);
		}

		// POST api/<LeaveTypesController>
		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> Post(CreateLeaveAllocationCommand command)
		{
			var response = await _mediator.Send(command);
			return CreatedAtAction(nameof(Get), new { id = response });
		}

		// PUT api/<LeaveTypesController>/5
		[HttpPut("{id}")]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Put(UpdateLeaveAllocationCommand command)
		{
			var response = await _mediator.Send(command);
			return NoContent();
		}

		// DELETE api/<LeaveTypesController>/5
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Delete(int id)
		{
			var command = new DeleteLeaveAllocationCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
