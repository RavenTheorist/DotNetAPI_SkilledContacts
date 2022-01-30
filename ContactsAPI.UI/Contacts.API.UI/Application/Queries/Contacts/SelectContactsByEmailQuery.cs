using Contacts.API.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.UI.Application.Queries.Contacts
{
	/// <summary>
	/// Query to select all the contacts by a given email
	/// </summary>
	public class SelectContactsByEmailQuery : IRequest<List<ContactDTO>>
	{
		#region Properties
		public string ContactEmail { get; set; }
		#endregion
	}
}
