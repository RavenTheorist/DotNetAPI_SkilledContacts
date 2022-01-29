using Contacts.Core.Skills.Domain;
using ContactsAPI.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contacts.API.UI.Application.Queries
{
	public class SelectAllSkillsHandler : IRequestHandler<SelectAllSkillsQuery, List<SkillResumeDTO>>
	{
		#region Fields
		private readonly ISkillRepository _repository = null;
		#endregion//Fields

		#region Constructors
		public SelectAllSkillsHandler(ISkillRepository repository)
		{
			this._repository = repository;
		}
		#endregion//Constructors

		#region Public methods
		public Task<List<SkillResumeDTO>> Handle(SelectAllSkillsQuery request, CancellationToken cancellationToken)
		{
			var skillsList = this._repository.GetAll(request.ContactEmail);
			var result = skillsList.Select(item => new SkillResumeDTO() { SkillName = item.Name, SkillLevel = item.Level, ContactEmail = item.Contact.Email, NbSkillsFromThisContact = (item.Contact?.Skills?.Count).GetValueOrDefault(0) }).ToList();

			return Task.FromResult(result);

		}
		#endregion//Public methods
	}
}
