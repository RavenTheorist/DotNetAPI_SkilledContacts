using Contacts.Core.Framework;
using Contacts.Core.Skills.Domain;
using Contacts.Core.Skills.Infrastructure.Data.TypeConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Core.Skills.Infrastructure.Data
{
	public class SkillsContext : IdentityDbContext, IUnitOfWork
	{
		#region Constructors
		public SkillsContext([NotNullAttribute] DbContextOptions options) : base(options) { }
		public SkillsContext() : base() { }
		#endregion//Constructors
		#region Properties
		public DbSet<Skill> Skills { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		#endregion//Properties

		#region Internal methods
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new SkillEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new ContactEntityTypeConfiguration());
		}
		#endregion//Internal methods
	}
}
