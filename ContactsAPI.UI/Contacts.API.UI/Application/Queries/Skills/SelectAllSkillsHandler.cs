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
	public class SelectAllSkillsHandler : IRequestHandler<SelectAllSkillsQuery, List<SkillDTO>>
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
		public Task<List<SkillDTO>> Handle(SelectAllSkillsQuery request, CancellationToken cancellationToken)
		{
			var skillsList = this._repository.GetAll();

			var result = skillsList.Select(item => new SkillDTO() { Id = item.Id, Name = item.Name, Level = item.Level }).ToList();

			return Task.FromResult(result);

		}
		#endregion//Public methods
	}
}
