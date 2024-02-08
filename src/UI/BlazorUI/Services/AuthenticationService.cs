using Blazored.LocalStorage;
using BlazorUI.Contracts;
using BlazorUI.Providers;
using BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorUI.Services
{
	public class AuthenticationService : BaseHttpService, IAuthenticationService
	{
		private readonly AuthenticationStateProvider _authenticationStateProvider;

		public AuthenticationService(IClient client,
			ILocalStorageService localStorage,
			AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
		{
			this._authenticationStateProvider = authenticationStateProvider;
		}

		public async Task<bool> AuthenticateAsync(string email, string password)
		{
			try
			{
				AuthRequest authRequest = new AuthRequest()
				{
					Email = email,
					Password = password
				};
				var authenticationResponse = await _client.LoginAsync(authRequest);
				if (authenticationResponse.Token != string.Empty)
				{
					await _localStorage.SetItemAsync("token", authenticationResponse.Token);
					//Set claims in Blazor and login state
					await ((ApiAuthenticationStateProvider)
						_authenticationStateProvider).LoggedIn();
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public async Task Logout()
		{
			//Remove claims in Blazor and invalidate login state
			await ((ApiAuthenticationStateProvider)
							_authenticationStateProvider).LoggedOut();
		}

		public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
		{
			RegistrationRequest registrationRequest = new RegistrationRequest()
			{
				FirstName = firstName,
				LastName = lastName,
				UserName = userName,
				Email = email,
				Password = password
			};
			var response = await _client.RegisterAsync(registrationRequest);

			if (!string.IsNullOrEmpty(response.UserId))
			{
				return true;
			}
			return false;
		}
	}
}
