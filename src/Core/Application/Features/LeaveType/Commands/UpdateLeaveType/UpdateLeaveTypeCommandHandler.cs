using Application.Contracts.Logging;
using Application.Exceptions;
using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveType.Commands.UpdateLeaveType
{
	public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
	{
		private readonly ILeaveTypeRepository _repository;

		private readonly IMapper _mapper;
		private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;

		public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository repository, IMapper mapper,
			IAppLogger<UpdateLeaveTypeCommandHandler> logger)
		{
			_repository = repository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			//validate incoming data
			var validator = new UpdateLeaveTypeCommandValidator(_repository);
			var validationResult = await validator.ValidateAsync(request);
			if (validationResult.Errors.Any())
			{
				_logger.LogWarning("Validation errors in update request for {0} - {1}",
					nameof(LeaveType), request.Id);
				throw new BadRequestException("Invalid Leave Type", validationResult);
			}

			//convert to domain entity object
			var leaveTypeToUpdate = _mapper.Map<LeaveManagement.Domain.LeaveType>(request);

			//update to database
			await _repository.UpdateAsync(leaveTypeToUpdate);

			//return 
			return Unit.Value;
		}
	}
}
