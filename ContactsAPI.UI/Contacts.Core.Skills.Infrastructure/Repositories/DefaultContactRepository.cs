using Contacts.Core.Framework;
using Contacts.Core.Skills.Domain;
using Contacts.Core.Skills.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Core.Skills.Infrastructure.Repositories
{
	public class DefaultContactRepository : IContactRepository
	{
		#region Fields
		private readonly Data.AppContext _context = null;
		#endregion//Fields
		#region Constructors
		public DefaultContactRepository(Data.AppContext context)
		{
			this._context = context;
		}
		#endregion//Constructors

		#region Public methods
		public Contact AddOne(Contact contact)
		{
			if (CanAddContact(in contact))
			{
				return this._context.Contacts.Add(contact).Entity;
			}

			return null;
		}

		public Contact UpdateOne(string contactEmail, Contact updateContactModel)
	{
			Contact existingContact = this._context.Contacts.FirstOrDefault(contact => contact.Email == contactEmail);

			if (existingContact != null)
			{
				if (updateContactModel.FirstName.Length > 0)
				{
					existingContact.FirstName = updateContactModel.FirstName;
				}

				if (updateContactModel.LastName.Length > 0)
				{
					existingContact.LastName = updateContactModel.LastName;
				}

				if (updateContactModel.Fullname.Length > 0)
				{
					existingContact.Fullname = updateContactModel.Fullname;
				}

				if (updateContactModel.Address.Length > 0)
				{
					existingContact.Address = updateContactModel.Address;
				}

				if (updateContactModel.MobilePhoneNumber.Length > 0)
				{
					existingContact.MobilePhoneNumber = updateContactModel.MobilePhoneNumber;
				}
			}

			return existingContact;
		}

		public ICollection<Contact> GetByEmail(string email)
		{
			var query = this._context.Contacts.Include(item => item.ContactSkills).AsQueryable();

			if (IsValidEmail(email))
			{
				query = query.Where(item => item.Email == email);
			}

			return query.ToList();
		}

		public ICollection<Contact> GetAll()
		{
			var query = this._context.Contacts.Include(item => item.ContactSkills).AsQueryable();

			return query.ToList();
		}

		public Contact DeleteOne(string contactEmail)
	{
			Contact deletedContact = null;

			if (this._context.Contacts.Count() > 0)
			{
				deletedContact = this._context.Contacts.FirstOrDefault(contact => contact.Email == contactEmail);

				if (deletedContact != null)
				{
					this._context.Contacts.Remove(deletedContact);
				}
			}

			return deletedContact;
		}
		#endregion//Public methods

		#region Private methods
		private bool CanAddContact(in Contact contactToBeChecked)
		{
			Contact existingContact = null;
			string emailToBeChecked = contactToBeChecked.Email;
			if (contactToBeChecked != null)
			{
				existingContact = this._context.Contacts.FirstOrDefault(contact => contact.Email == emailToBeChecked);
			}

			bool contactAlreadyExists = existingContact != null;

			return		!contactAlreadyExists
					&&	IsValidEmail(contactToBeChecked.Email)
					&&	contactToBeChecked.FirstName.Length > 0
					&&	contactToBeChecked.LastName.Length > 0
					&&	contactToBeChecked.Fullname.Length > 0
					&&	contactToBeChecked.Address.Length > 0;
		}

		private bool IsValidEmail(string email)
		{
			var trimmedEmail = email.Trim();

			if (trimmedEmail.EndsWith("."))
			{
				return false; // suggested by @TK-421
			}
			try
			{
				var addr = new System.Net.Mail.MailAddress(email);
				return addr.Address == trimmedEmail;
			}
			catch
			{
				return false;
			}
		}
		#endregion//Private methods

		#region Properties
		public IUnitOfWork UnitOfWork => this._context;
		#endregion//Properties
	}
}
