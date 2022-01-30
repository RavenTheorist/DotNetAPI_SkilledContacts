using Contacts.Core.Framework;
using Contacts.Core.Skills.Domain;
using Contacts.Core.Skills.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Core.Skills.Infrastructure.Repositories
{
	public class DefaultSkillRepository : ISkillRepository
	{
		#region Fields
		private readonly Data.AppContext _context = null;
		#endregion//Fields
		#region Constructors
		public DefaultSkillRepository(Data.AppContext context)
		{
			this._context = context;
		}
		#endregion//Constructors

		#region Public methods
		public Skill AddOne(Skill skill)
		{
			return this._context.Skills.Add(skill).Entity;
		}

		public Skill UpdateOne(int skillId, Skill updatedSkill)
		{
			Skill existingSkill = this._context.Skills.Where(skill => skill.Id == skillId).First();

			existingSkill.Name = updatedSkill.Name;
			existingSkill.Level = updatedSkill.Level;

			return existingSkill;
		}

		
		public ICollection<Skill> GetByName(string skillName)
		{
			var query = this._context.Skills.Include(item => item.ContactSkills).AsQueryable();

			if (skillName.Length >= 0)
			{
				query = query.Where(item => item.Name == skillName);
			}

			return query.ToList();
		}

		public ICollection<Skill> GetAll()
		{
			var query = this._context.Skills.Include(item => item.ContactSkills).AsQueryable();

			return query.ToList();
		}

		public Skill DeleteOne(int skillId)
		{
			Skill deletedSkill = null;

			if (this._context.Skills.Count() > 0)
			{
				deletedSkill = this._context.Skills.Single(skill => skill.Id == skillId);

				if (deletedSkill != null)
				{
					this._context.Skills.Remove(deletedSkill);
				}
			}

			return deletedSkill;
		}
		#endregion//Public methods

		#region Properties
		public IUnitOfWork UnitOfWork => this._context;
		#endregion//Properties
	}
}
