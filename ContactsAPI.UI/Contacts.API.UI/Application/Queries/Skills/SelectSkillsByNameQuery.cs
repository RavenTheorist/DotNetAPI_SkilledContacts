using ContactsAPI.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.UI.Application.Queries
{
	/// <summary>
	/// Query to select all the skills by a given name
	/// </summary>
	public class SelectSkillsByNameQuery : IRequest<List<SkillDTO>>
	{
		#region Properties
		public string SkillName { get; set; }
		#endregion
	}
}
