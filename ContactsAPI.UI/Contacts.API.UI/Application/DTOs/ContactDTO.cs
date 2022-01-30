using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.UI.Application.DTOs
{
	public class ContactDTO
	{
		public string Email { get; set; }
		public string Address { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Fullname { get; set; }
		[Phone]
		public string MobilePhoneNumber { get; set; }
	}
}
