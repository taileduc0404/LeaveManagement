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
		public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			//validate incoming data

			//convert to domain entity object
			var leaveTypeToUpdate = _mapper.Map<LeaveManagement.Domain.LeaveType>(request);

			//update to database
			await _repository.UpdateAsync(leaveTypeToUpdate);

			//return 
			return Unit.Value;
		}
	}
}
