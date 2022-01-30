using Contacts.API.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.UI.Application.Commands.Contacts
{
	/// <summary>
	/// Delete one contact from the database
	/// </summary>
	public class DeleteContactCommand : IRequest<ContactDTO>
	{
		public string ContactEmail { get; set; }
	}
}
