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
		/// Get all the Skills using a given name
		/// </summary>
		/// <param name="skillName">Selector</param>
		ICollection<Skill> GetByName(string skillName);

		/// <summary>
		/// Get all the Skills
		/// </summary>
		ICollection<Skill> GetAll();

		/// <summary>
		/// Updates one skill with the given values
		/// </summary>
		/// <param name="skillId">Searched skill Id</param>
		/// <param name="updatedSkill">Values for the new skill Id</param>
		Skill UpdateOne(int skillId, Skill updatedSkill);

		/// <summary>
		/// Add one skill in the database
		/// </summary>
		/// <param name="skill">Given Skill to add</param>
		/// <returns>Added Skill</returns>
		Skill AddOne(Skill skill);

		/// <summary>
		/// Delete one skill from the database
		/// </summary>
		/// <param name="skillId">Skill Id corresponding to the entry to be deleted</param>
		Skill DeleteOne(int skillId);
	}
}
