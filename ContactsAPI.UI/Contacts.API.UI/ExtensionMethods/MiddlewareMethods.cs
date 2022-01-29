using Contacts.API.UI.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.UI.ExtensionMethods
{
	public static class MiddlewareMethods
	{
		#region Public methods
		public static void UseCustomMiddlewares(this IApplicationBuilder app)
		{
			app.UseMiddleware<LogRequestMiddleware>();
		}
		#endregion//Public methods
	}
}
