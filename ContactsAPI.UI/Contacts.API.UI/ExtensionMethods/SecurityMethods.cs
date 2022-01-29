using Contacts.Core.Skills.Infrastructure.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.UI.ExtensionMethods
{
	/// <summary>
	/// Holds CORS and JWT security methods
	/// </summary>
	public static class SecurityMethods
	{
		#region Constants
		public const string DEFAULT_POLICY = "DEFAULT_POLICY";
		public const string DEFAULT_POLICY_2 = "DEFAULT_POLICY_2";
		public const string DEFAULT_POLICY_3 = "DEFAULT_POLICY_3";
		#endregion//Constants

		#region Public methods
		/// <summary>
		/// Add CORS and JWT configurations
		/// </summary>
		/// <param name="services"></param>
		public static void AddCustomSecurity(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddCustomCors(configuration); // CORS
			services.AddCustomAuthentication(configuration); // JWT
		}

		public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
		{
			// Bind the Secrets.json JWT.Key to a new SecurityOption's attribute named "Key"
			SecurityOption securityOption = new SecurityOption();
			configuration.GetSection("Jwt").Bind(securityOption);

			services.AddAuthentication(options =>
			{
				// Selects which model to use, which determines how to communicate and use the communication headers
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				string myKey = securityOption.Key;
				options.SaveToken = true; // Should the token be saved
				// Set the Authentication params
				options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
				{
					IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(myKey)),
					ValidateAudience = false,
					ValidateIssuer = false,
					ValidateActor = false,
					ValidateLifetime = true // Sets a timeout for the token
				};
			});
		}

		public static void AddCustomCors(this IServiceCollection services, IConfiguration configuration)
		{
			// Bind the Json Cors.Origin to a new CorsOption's attribute named "Origin"
			CorsOption corsOption = new CorsOption();
			configuration.GetSection("Cors").Bind(corsOption);

			services.AddCors(options =>
			{
				options.AddPolicy(DEFAULT_POLICY, builder =>
				{
					builder.WithOrigins(corsOption.Origin)				// Allow anything from any origin
						   .AllowAnyHeader()                            // Allow anything coming from headers
						   .AllowAnyMethod();                           // Allow all methods (GET, PUT, POST, etc)
				});

				options.AddPolicy(DEFAULT_POLICY_2, builder =>
				{
					builder.WithOrigins("http://127.0.0.1:5501")    // Allow anything from any origin
						   .AllowAnyHeader()                        // Allow anything coming from headers
						   .AllowAnyMethod();                       // Allow all methods (GET, PUT, POST, etc)
				});

				options.AddPolicy(DEFAULT_POLICY_3, builder =>
				{
					builder.WithOrigins("http://127.0.0.1:5502")    // Allow anything from any origin
						   .AllowAnyHeader()                        // Allow anything coming from headers
						   .AllowAnyMethod();                       // Allow all methods (GET, PUT, POST, etc)
				});
			});
		}
		#endregion//Public methods
		}
}
