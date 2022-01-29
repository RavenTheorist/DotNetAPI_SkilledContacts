using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Core.Skills.Infrastructure.Loggers
{
	public class CustomLoggerProvider : ILoggerProvider
	{
		#region Fields
		private ConcurrentDictionary<string, CustomMessageLogger> _loggers = new ConcurrentDictionary<string, CustomMessageLogger>();
		#endregion//Fields

		#region Public methods
		ILogger ILoggerProvider.CreateLogger(string categoryName)
		{
			this._loggers.GetOrAdd(categoryName, key => new CustomMessageLogger());

			return this._loggers[categoryName];
		}

		void IDisposable.Dispose()
		{
			this._loggers.Clear();
		}
		#endregion//Public methods
	}
}
