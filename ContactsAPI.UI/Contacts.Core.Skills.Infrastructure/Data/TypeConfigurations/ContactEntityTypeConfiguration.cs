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
	class ContactEntityTypeConfiguration : IEntityTypeConfiguration<Contact>
	{
		#region Public methods
		public void Configure(EntityTypeBuilder<Contact> builder)
		{
			builder.ToTable("Contact");

			builder.HasKey(item => item.Email);
		}
		#endregion//Public methods
	}
}
