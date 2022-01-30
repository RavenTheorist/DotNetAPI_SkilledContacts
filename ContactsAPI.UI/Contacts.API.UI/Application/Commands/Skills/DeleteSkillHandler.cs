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
	public class DeleteSkillHandler : IRequestHandler<DeleteSkillCommand, SkillDTO>
	{
		#region Fields
		private readonly ISkillRepository _repository = null;
		#endregion//Fields

		#region Constructors
		public DeleteSkillHandler(ISkillRepository repository)
		{
			this._repository = repository;
		}
		#endregion//Constructors

		#region Public methods
		public Task<SkillDTO> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
		{
			// Don't set the ID, because it increments automatically...
			Skill deletedSkill = this._repository.DeleteOne(request.SkillId);

			// Save to database
			try
			{
				_repository.UnitOfWork.SaveChanges();
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception thrown while trying to save db changes: %s", e.Message);
			}

			SkillDTO result = null;
			if (deletedSkill != null)
			{
				result = new SkillDTO { Id = deletedSkill.Id, Level = deletedSkill.Level, Name = deletedSkill.Name };
			}

			return Task.FromResult(result);
		}
		#endregion//Public methods
	}
}
