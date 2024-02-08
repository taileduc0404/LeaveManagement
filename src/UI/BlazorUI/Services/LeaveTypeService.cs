using AutoMapper;
using Blazored.LocalStorage;
using BlazorUI.Contracts;
using BlazorUI.Models.LeaveTypes;
using BlazorUI.Services.Base;

namespace BlazorUI.Services
{
	public class LeaveTypeService : BaseHttpService, ILeaveTypeService
	{
		private readonly IMapper _mapper;

		public LeaveTypeService(IClient client, IMapper mapper, ILocalStorageService localStorageService) : base(client, localStorageService)
		{
			this._mapper = mapper;
		}


		public async Task<Response<Guid>> CreateLeaveType(LeaveTypeVM vm)
		{
			try
			{
				await AddBearerToken();
				var createLeaveTypeCommand = _mapper.Map<CreateLeaveTypeCommand>(vm);
				await _client.LeaveTypesPOSTAsync(createLeaveTypeCommand);
				return new Response<Guid>()
				{
					Success = true,
				};
			}
			catch (ApiException ex)
			{
				return ConvertApiException<Guid>(ex);
			}
		}

		public async Task<Response<Guid>> DeleteLeaveType(int id)
		{
			try
			{
				await AddBearerToken();
				await _client.LeaveTypesDELETEAsync(id);
				return new Response<Guid>()
				{
					Success = true,
				};

			}
			catch (ApiException ex)
			{
				return ConvertApiException<Guid>(ex);
			}
		}

		public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
		{
			await AddBearerToken();
			var leaveType = await _client.LeaveTypesGETAsync(id);
			return _mapper.Map<LeaveTypeVM>(leaveType);
		}

		public async Task<List<LeaveTypeVM>> GetLeaveTypes()
		{
			await AddBearerToken();
			var leaveTypes = await _client.LeaveTypesAllAsync();
			return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);

		}

		public async Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVM vm)
		{
			try
			{
				await AddBearerToken();
				var updateLeaveTypeCommand = _mapper.Map<UpdateLeaveTypeCommand>(vm);
				await _client.LeaveTypesPUTAsync(id.ToString(), updateLeaveTypeCommand);
				return new Response<Guid>()
				{
					Success = true,
				};
			}
			catch (ApiException ex)
			{
				return ConvertApiException<Guid>(ex);
			}
		}
	}
}
