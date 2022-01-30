using Contacts.Core.Skills.Domain;
using ContactsAPI.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contacts.API.UI.Application.Commands
{
	public class UpdateSkillHandler : IRequestHandler<UpdateSkillCommand, SkillDTO>
	{
		#region Fields
		private readonly ISkillRepository _repository = null;
		#endregion//Fields

		#region Constructors
		public UpdateSkillHandler(ISkillRepository repository)
		{
			this._repository = repository;
		}
		#endregion//Constructors

		#region Public methods
		public Task<SkillDTO> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
		{
			SkillDTO result = null;

			// Don't set the ID, because it increments automatically...
			Skill updatedSkill = this._repository.UpdateOne(request.SkillId, new Skill()
			{
				Id = request.SkillDto.Id,
				Name = request.SkillDto.Name,
				Level = request.SkillDto.Level
			});

			// Save to database
			try
			{
				_repository.UnitOfWork.SaveChanges();
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception thrown while trying to save db changes: %s", e.Message);
			}

			if (updatedSkill != null)
			{
				// ...get the auto generated ID
				result = request.SkillDto;
			}

			return Task.FromResult(result);
		}
		#endregion//Public methods
	}
}
