using ContactsAPI.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.UI.Application.Queries
{
	/// <summary>
	/// Query to select all skills (through a DTO class)
	/// </summary>
	public class SelectAllSkillsQuery : IRequest<List<SkillResumeDTO>>
	{
		#region Properties
		public string ContactEmail { get; set; }
		#endregion
	}
}
