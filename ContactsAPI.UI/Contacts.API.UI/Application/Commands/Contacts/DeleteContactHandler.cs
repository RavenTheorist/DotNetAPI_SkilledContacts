using Contacts.Core.Skills.Domain;
using Contacts.API.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contacts.API.UI.Application.Commands.Contacts
{
	public class DeleteContactHandler : IRequestHandler<DeleteContactCommand, ContactDTO>
	{
		#region Fields
		private readonly IContactRepository _repository = null;
		#endregion//Fields

		#region Constructors
		public DeleteContactHandler(IContactRepository repository)
		{
			this._repository = repository;
		}
		#endregion//Constructors

		#region Public methods
		public Task<ContactDTO> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
		{
			// Don't set the ID, because it increments automatically...
			Contact deletedContact = this._repository.DeleteOne(request.ContactEmail);

			// Save to database
			try
			{
				_repository.UnitOfWork.SaveChanges();
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception thrown while trying to save db changes: %s", e.Message);
			}

			ContactDTO result = null;

			if (deletedContact != null)
			{
				result = new ContactDTO
				{
					Email = deletedContact.Email,
					FirstName = deletedContact.FirstName,
					LastName = deletedContact.LastName,
					Fullname = deletedContact.Fullname,
					Address = deletedContact.Address,
					MobilePhoneNumber = deletedContact.MobilePhoneNumber
				};
			}

			return Task.FromResult(result);
		}
		#endregion//Public methods
	}
}
