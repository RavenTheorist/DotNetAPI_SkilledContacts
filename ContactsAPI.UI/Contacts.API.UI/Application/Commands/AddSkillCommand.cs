using ContactsAPI.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.UI.Application.Commands
{
	/// <summary>
	/// Command to add one skill into the database
	/// </summary>
	public class AddSkillCommand : IRequest<SkillDTO>
	{
		#region Properties
		public SkillDTO SkillDto { get; set; }
		#endregion//Properties
	}
}
