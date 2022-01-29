using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Core.Skills.Domain
{
	/// <summary>
	/// Contact skill
	/// </summary>
	public class Skill
	{
		#region Properties
		public string Name { get; set; }
		public int Level { get; set; }
		public string ContactEmail { get; set; }
		public Contact Contact { get; set; }
		#endregion//Properties
	}
}
