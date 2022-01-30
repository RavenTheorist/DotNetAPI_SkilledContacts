using Contacts.API.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.UI.Application.Commands.Contacts
{
	/// <summary>
	/// Command to update one contact in the database
	/// </summary>
	public class UpdateContactCommand : IRequest<ContactDTO>
	{
		#region Properties
		public string ContactEmail { get; set; }
		public ContactDTO ContactDto { get; set; }
		#endregion//Properties
	}
}
