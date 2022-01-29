using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Core.Framework
{
	/// <summary>
	/// Use it to define any repository class
	/// </summary>
	public interface IRepository
	{
		IUnitOfWork UnitOfWork { get; }
	}
}
