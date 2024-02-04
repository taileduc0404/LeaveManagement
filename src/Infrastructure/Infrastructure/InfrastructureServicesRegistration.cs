using Application.Contracts.Email;
using Application.Contracts.Logging;
using Application.Models.Email;
using Infrastructure.EmailService;
using Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServicesRegistration
{
	public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
		services.AddTransient<IEmailSender, EmailSender>();
		services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
		return services;
	}
}
