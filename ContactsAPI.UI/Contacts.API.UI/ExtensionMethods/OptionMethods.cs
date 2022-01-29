using Contacts.Core.Skills.Infrastructure.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.UI.ExtensionMethods
{
	/// <summary>
	/// Custom JSon configuration options
	/// </summary>
	public static class OptionMethods
	{
		#region Public methods
		/// <summary>
		/// Add custom options from the JSon config
		/// </summary>
		/// <param name="services"></param>
		public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<SecurityOption>(configuration.GetSection("Jwt"));
		}
		#endregion//Public methods
	}
}
