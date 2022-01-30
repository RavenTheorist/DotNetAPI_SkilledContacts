using ContactsAPI.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.UI.Application.Commands
{
	public class DeleteSkillCommand : IRequest<SkillDTO>
	{
		public int SkillId { get; set; }
	}
}
