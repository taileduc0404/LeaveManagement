using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using BlazorUI;
using BlazorUI.Pages.LeaveTypes;
using BlazorUI.Shared;
using BlazorUI.Models;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorUI.Services;
using BlazorUI.Contracts;
using BlazorUI.Providers;

namespace BlazorUI.Pages
{
	public partial class Index
	{
		[Inject]
		private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

		[Inject]
		public NavigationManager NavigationManager { get; set; }

		[Inject]
		public IAuthenticationService AuthenticationService { get; set; }

		protected async override Task OnInitializedAsync()
		{
			await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
		}

		protected void GoToLogin()
		{
			NavigationManager.NavigateTo("login/");
		}

		protected void GoToRegister()
		{
			NavigationManager.NavigateTo("register/");
		}

		protected async void Logout()
		{
			await AuthenticationService.Logout();
		}
	}
}