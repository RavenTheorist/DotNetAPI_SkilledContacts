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
	public class SelectSkillsByNameHandler : IRequestHandler<SelectSkillsByNameQuery, List<SkillDTO>>
	{
		#region Fields
		private readonly ISkillRepository _repository = null;
		#endregion//Fields

		#region Constructors
		public SelectSkillsByNameHandler(ISkillRepository repository)
		{
			this._repository = repository;
		}
		#endregion//Constructors

		#region Public methods
		public Task<List<SkillDTO>> Handle(SelectSkillsByNameQuery request, CancellationToken cancellationToken)
		{
			var skillsList = this._repository.GetByName(request.SkillName);

			//result = skillsList.Select(item => new SkillResumeDTO() { SkillId = item.Id, SkillName = item.Name, SkillLevel = item.Level, NbSkillsFromThisContact = item.Contacts?.Count }).ToList();

			var result = skillsList.Select(item => new SkillDTO() { Id = item.Id, Name = item.Name, Level = item.Level }).ToList();

			return Task.FromResult(result);

		}
		#endregion//Public methods
	}
}
