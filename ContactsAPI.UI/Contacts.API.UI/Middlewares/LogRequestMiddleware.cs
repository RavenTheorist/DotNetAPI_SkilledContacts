using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.UI.Middlewares
{
	public class LogRequestMiddleware
	{
		#region Fields
		private RequestDelegate _next = null;
		private ILogger<LogRequestMiddleware> _logger = null;
		#endregion//Fields

		#region Constructors
		public LogRequestMiddleware(RequestDelegate next, ILogger<LogRequestMiddleware> logger)
		{
			this._next = next;
			this._logger = logger;
		}
		#endregion//Constructors

		#region Public methods
		public async Task Invoke(HttpContext context)
		{
			this._logger.LogDebug(context.Request.Path.Value);

			await this._next(context);
		}
		#endregion//Public methods
	}
}
