using Contacts.API.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.UI.Application.Commands.Contacts
{
	/// <summary>
	/// Command to add one contact into the database
	/// </summary>
	public class AddContactCommand : IRequest<ContactDTO>
	{
		#region Properties
		public ContactDTO ContactDto { get; set; }
		#endregion//Properties
	}
}
