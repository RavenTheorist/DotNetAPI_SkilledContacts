using Contacts.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Core.Skills.Domain
{
	/// <summary>
	/// Repository to manage Skills
	/// </summary>
	public interface ISkillRepository : IRepository
	{
		/// <summary>
		/// Get all the Skills
		/// </summary>
		ICollection<Skill> GetAll(string contactEmail);

		/// <summary>
		/// Add one skill in the database
		/// </summary>
		/// <param name="skill">Given Skill to add</param>
		/// <returns>Added Skill</returns>
		Skill AddOne(Skill skill);
	}
}
