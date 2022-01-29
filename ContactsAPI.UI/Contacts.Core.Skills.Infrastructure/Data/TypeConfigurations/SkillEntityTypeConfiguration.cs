using Contacts.Core.Skills.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Core.Skills.Infrastructure.Data.TypeConfigurations
{
	class SkillEntityTypeConfiguration : IEntityTypeConfiguration<Skill>
	{
		#region Public methods
		public void Configure(EntityTypeBuilder<Skill> builder)
		{
			builder.ToTable("Skill");

			builder.HasKey(item => item.ContactEmail);
			builder.HasOne(item => item.Contact).WithMany(item => item.Skills);
		}
		#endregion//Public methods
	}
}
