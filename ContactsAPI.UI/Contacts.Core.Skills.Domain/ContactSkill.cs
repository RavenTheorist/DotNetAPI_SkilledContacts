using Contacts.Core.Skills.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Core.Skills.Domain
{
	/// <summary>
	/// Associative table between a Contact and a Skill, for the many to many relationship
	/// </summary>
	public class ContactSkill
	{
		#region Properties
		public int Id { get; set; }

		public string ContactEmail { get; set; }
		public Contact Contact { get; set; }

		public int SkillId { get; set; }
		public Skill Skill { get; set; }
		#endregion//Properties
	}
}
