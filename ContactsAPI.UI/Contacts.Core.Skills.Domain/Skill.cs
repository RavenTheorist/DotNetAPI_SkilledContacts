using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Core.Skills.Domain
{
	/// <summary>
	/// Skill object class
	/// </summary>
	public class Skill
	{
		#region Properties
		public int Id { get; set; }
		public string Name { get; set; }
		public int Level { get; set; }
		public List<Contact> Contacts { get; set; }

		// Navigation Properties
		public List<ContactSkill> ContactSkills { get; set; }
		#endregion//Properties
	}
}
