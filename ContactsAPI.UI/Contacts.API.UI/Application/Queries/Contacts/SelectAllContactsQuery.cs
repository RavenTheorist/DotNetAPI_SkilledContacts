using Contacts.API.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.UI.Application.Queries.Contacts
{
	/// <summary>
	/// Query to select all contacts (through a DTO class)
	/// </summary>
	public class SelectAllContactsQuery : IRequest<List<ContactDTO>>
	{
	}
}
