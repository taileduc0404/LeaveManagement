namespace BlazorUI.Services.Base
{
	public class BaseHttpService
	{
		protected IClient _client;
		public BaseHttpService(IClient client)
		{
			_client = client;
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
	}
}
