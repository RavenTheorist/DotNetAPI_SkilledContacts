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
	class ContactSkillEntityTypeConfiguration : IEntityTypeConfiguration<ContactSkill>
	{
		#region Public methods
		public void Configure(EntityTypeBuilder<ContactSkill> builderModel)
		{
			builderModel.HasKey(contactSkill => new { contactSkill.ContactEmail, contactSkill.SkillId });

			builderModel
				.HasOne(skill => skill.Contact)
				.WithMany(contactSkill => contactSkill.ContactSkills)
				.HasForeignKey(contact => contact.ContactEmail);

			builderModel
				.HasOne(contact => contact.Skill)
				.WithMany(contactSkill => contactSkill.ContactSkills)
				.HasForeignKey(skill => skill.SkillId);
		}
		#endregion//Public methods
	}
}
