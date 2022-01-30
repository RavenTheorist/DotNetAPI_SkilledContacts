using ContactsAPI.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.UI.Application.Commands
{
	/// <summary>
	/// Command to update one skill in the database
	/// </summary>
	public class UpdateSkillCommand : IRequest<SkillDTO>
	{
		#region Properties
		public int SkillId { get; set; }
		public SkillDTO SkillDto { get; set; }
		#endregion//Properties
	}
}
