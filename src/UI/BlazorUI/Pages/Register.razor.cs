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
using BlazorUI.Contracts;

namespace BlazorUI.Pages
{
	public partial class Register
	{
		public RegisterVM Model { get; set; }

		[Inject]
		public NavigationManager NavigationManager { get; set; }

		public string Message { get; set; }

		[Inject]
		private IAuthenticationService AuthenticationService { get; set; }

		protected override void OnInitialized()
		{
			Model = new RegisterVM();
		}

		protected async Task HandleRegister()
		{
			var result = await AuthenticationService.RegisterAsync(Model.FirstName, Model.LastName, Model.UserName, Model.Email, Model.Password);

			if (result)
			{
				NavigationManager.NavigateTo("/");
			}
			Message = "Something went wrong, please try again.";
		}
	}
}