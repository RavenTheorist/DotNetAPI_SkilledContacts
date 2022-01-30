using Contacts.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Core.Skills.Domain
{
	/// <summary>
	/// Repository to manage Contacts
	/// </summary>
	public interface IContactRepository : IRepository
	{
		/// <summary>
		/// Get all the Contacts using a given email
		/// </summary>
		/// <param name="email">Selector</param>
		ICollection<Contact> GetByEmail(string email);

		/// <summary>
		/// Get all the Contacts
		/// </summary>
		ICollection<Contact> GetAll();

		/// <summary>
		/// Updates one contact with the given values
		/// </summary>
		/// <param name="contactEmail">Searched contact Email as a key of search</param>
		/// <param name="updatedContact">Values for the new contact Id</param>
		Contact UpdateOne(string contactEmail, Contact updatedContact);

		/// <summary>
		/// Add one contact in the database
		/// </summary>
		/// <param name="contact">Given Contact to add</param>
		/// <returns>Added Contact</returns>
		Contact AddOne(Contact contact);

		/// <summary>
		/// Delete one contact from the database
		/// </summary>
		/// <param name="contactId">Contact Email corresponding to the entry to be deleted</param>
		Contact DeleteOne(string contactEmail);
	}
}
