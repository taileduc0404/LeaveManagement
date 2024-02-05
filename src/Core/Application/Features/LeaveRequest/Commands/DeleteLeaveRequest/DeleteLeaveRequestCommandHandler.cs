using Application.Exceptions;
using AutoMapper;
using LeaveManagement.Application.Contracts.Persistences;
using MediatR;

namespace Application.Features.LeaveRequest.Commands.DeleteLeaveRequest
{
	public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
	{
		private readonly ILeaveRequestRepository _repository;
		private readonly IMapper _mapper;

		public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
		{
			var leaveRequest = await _repository.GetLeaveRequestWithDetails(request.Id);
			if (leaveRequest == null)
			{
				throw new NotFoundException(nameof(LeaveRequest), request.Id);
			}

			await _repository.DeleteAsync(leaveRequest);
			return Unit.Value;
		}
	}
}
