using Contacts.API.UI;
using Contacts.Core.Skills.Domain;
using Contacts.Core.Skills.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.UI.ExtensionMethods
{
	public static class DIMethods
	{
		#region Public methods
		/// <summary>
		/// Prepare custom dependency injections
		/// </summary>
		/// <param name="services"></param>
		public static IServiceCollection AddInjections(this IServiceCollection services)
		{
			services.AddScoped<ISkillRepository, DefaultSkillRepository>();
			services.AddMediatR(typeof(Startup));

			return services;
		}
		#endregion//Public methods
	}
}
