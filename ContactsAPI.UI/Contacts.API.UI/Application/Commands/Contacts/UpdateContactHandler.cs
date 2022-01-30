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
	public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, ContactDTO>
	{
		#region Fields
		private readonly IContactRepository _repository = null;
		#endregion//Fields

		#region Constructors
		public UpdateContactHandler(IContactRepository repository)
		{
			this._repository = repository;
		}
		#endregion//Constructors

		#region Public methods
		public Task<ContactDTO> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
		{
			ContactDTO result = null;

			// Don't set the ID, because it increments automatically...
			Contact updatedContact = this._repository.UpdateOne(request.ContactEmail, new Contact()
			{
				Email = request.ContactDto.Email,
				FirstName = request.ContactDto.FirstName,
				LastName = request.ContactDto.LastName,
				Fullname = request.ContactDto.Fullname,
				Address = request.ContactDto.Address,
				MobilePhoneNumber = request.ContactDto.MobilePhoneNumber
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

			if (updatedContact != null)
			{
				result = request.ContactDto;
			}

			return Task.FromResult(result);
		}
		#endregion//Public methods
	}
}
