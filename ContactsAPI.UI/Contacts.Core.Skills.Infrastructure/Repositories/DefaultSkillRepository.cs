﻿using Contacts.Core.Framework;
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
		private readonly SkillsContext _context = null;
		#endregion//Fields
		#region Constructors
		public DefaultSkillRepository(SkillsContext context)
		{
			this._context = context;
		}
		#endregion//Constructors

		#region Public methods
		public ICollection<Skill> GetAll(string contactEmail)
		{
			var query = this._context.Skills.Include(item => item.Contact).AsQueryable();

			if (contactEmail.Length > 0)
			{
				query = query.Where(item => item.ContactEmail == contactEmail);
			}

			return query.ToList();
		}

		public Skill AddOne(Skill skill)
		{
			return this._context.Skills.Add(skill).Entity;
		}
		#endregion//Public methods

		#region Properties
		public IUnitOfWork UnitOfWork => this._context;
		#endregion//Properties
	}
}