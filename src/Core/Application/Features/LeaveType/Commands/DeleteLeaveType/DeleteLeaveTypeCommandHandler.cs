using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveType.Commands.DeleteLeaveType
{
	public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
	{
		private readonly ILeaveTypeRepository _repository;

		private readonly IMapper _mapper;
		public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			//retrieve to domain entity object
			var leaveTypeDelete = await _repository.GetByIdAsync(request.Id);

			//verify that record exists

			//delete
			await _repository.DeleteAsync(leaveTypeDelete);

			//return 
			return Unit.Value;
		}
	}
}
