using Contacts.API.UI.Application.Commands;
using Contacts.Core.Skills.Domain;
using ContactsAPI.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contacts.API.UI.Controllers
{
	public class AddSkillHandler : IRequestHandler<AddSkillCommand, SkillDTO>
	{
		#region Fields
		private readonly ISkillRepository _repository = null;
		#endregion//Fields

		#region Constructors
		public AddSkillHandler(ISkillRepository repository)
		{
			this._repository = repository;
		}
		#endregion//Constructors

		#region Public methods
		public Task<SkillDTO> Handle(AddSkillCommand request, CancellationToken cancellationToken)
		{
			SkillDTO result = null;

			// Don't set the ID, because it increments automatically...
			Skill addedSkill = this._repository.AddOne(new Skill()
			{
				Id = request.SkillDto.Id,
				Name = request.SkillDto.Name
			});

			// Save to database
			_repository.UnitOfWork.SaveChanges();

			if (addedSkill != null)
			{
				// ...get the auto generated ID
				request.SkillDto.Name = addedSkill.Name;
				result = request.SkillDto;
			}

			return Task.FromResult(result);
		}
		#endregion//Public methods
	}
}
