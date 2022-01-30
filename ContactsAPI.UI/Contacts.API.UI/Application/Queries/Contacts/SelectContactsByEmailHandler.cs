using Contacts.Core.Skills.Domain;
using Contacts.API.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contacts.API.UI.Application.Queries.Contacts
{
	public class SelectContactsByEmailHandler : IRequestHandler<SelectContactsByEmailQuery, List<ContactDTO>>
	{
		#region Fields
		private readonly IContactRepository _repository = null;
		#endregion//Fields

		#region Constructors
		public SelectContactsByEmailHandler(IContactRepository repository)
		{
			this._repository = repository;
		}
		#endregion//Constructors

		#region Public methods
		public Task<List<ContactDTO>> Handle(SelectContactsByEmailQuery request, CancellationToken cancellationToken)
		{
			var contactsList = this._repository.GetByEmail(request.ContactEmail);

			var result = contactsList.Select(item => new ContactDTO()
			{
				Email = item.Email,
				FirstName = item.FirstName,
				LastName = item.LastName,
				Fullname = item.Fullname,
				Address = item.Address,
				MobilePhoneNumber = item.MobilePhoneNumber
			}).ToList();

			return Task.FromResult(result);

		}
		#endregion//Public methods
	}
}
