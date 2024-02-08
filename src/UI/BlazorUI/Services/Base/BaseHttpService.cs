using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace BlazorUI.Services.Base
{
	public class BaseHttpService
	{
		protected IClient _client;
		protected readonly ILocalStorageService _localStorage;

		public BaseHttpService(IClient client, ILocalStorageService localStorage)
		{
			_client = client;
			this._localStorage = localStorage;
		}

		protected Response<Guid> ConvertApiException<Gui>(ApiException e)
		{
			if (e.StatusCode == 400)
			{
				return new Response<Guid>()
				{
					Message = "Invalid data was submitted.",
					ValidaionErrors = e.Response,
					Success = false
				};
			}
			else if (e.StatusCode == 404)
			{
				return new Response<Guid>()
				{
					Message = "The record was not found.",
					ValidaionErrors = e.Response,
					Success = false
				};
			}
			else
			{
				return new Response<Guid>()
				{
					Message = "Something went wrong, please try again later.",
					ValidaionErrors = e.Response,
					Success = false
				};
			}
		}

		protected async Task AddBearerToken()
		{
			if (await _localStorage.ContainKeyAsync("token"))
				_client.HttpClient.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Bearer", await
					_localStorage.GetItemAsync<string>("token"));
		}
	}
}
