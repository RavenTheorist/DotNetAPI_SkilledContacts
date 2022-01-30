using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Contacts.Core.Skills.Domain
{
	/// <summary>
	/// Contact object class
	/// </summary>
	public class Contact
	{
		#region Properties
		[Required]
		public string Email { get; set; }
		public string Address { get; set; }
		public string FirstName { get; set; }
		public string Fullname { get; set; }
		[Phone]
		public string MobilePhoneNumber { get; set; }

		// Navigation Properties
		public List<ContactSkill> ContactSkills { get; set; }
		#endregion//Properties
	}
}
