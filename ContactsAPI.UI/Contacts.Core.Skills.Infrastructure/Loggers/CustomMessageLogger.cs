using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Core.Skills.Infrastructure.Loggers
{
	public class CustomMessageLogger : ILogger
	{
		#region Public methods
		IDisposable ILogger.BeginScope<TState>(TState state)
		{
			return null;
		}

		bool ILogger.IsEnabled(LogLevel logLevel)
		{
			return logLevel != LogLevel.Trace;
		}

		void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			Console.WriteLine($"[{DateTime.Now}]: #{logLevel.ToString()}# {formatter(state, exception)}");
		}
		#endregion//Public methods
	}
}
