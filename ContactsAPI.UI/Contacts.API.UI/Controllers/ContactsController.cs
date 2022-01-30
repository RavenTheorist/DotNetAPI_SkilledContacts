using Contacts.API.UI.ExtensionMethods;
using Contacts.Core.Skills.Domain;
using Contacts.Core.Skills.Infrastructure.Data;
using ContactsAPI.UI.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Contacts.API.UI.Application.Queries;
using Contacts.API.UI.Application.Commands;
using Contacts.API.UI.Application.Queries.Contacts;
using Contacts.API.UI.Application.Commands.Contacts;
using Contacts.API.UI.Application.DTOs;

namespace Contacts.API.UI.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[EnableCors(SecurityMethods.DEFAULT_POLICY)]
	public class ContactsController : ControllerBase
	{
		#region Fields
		private readonly IMediator _mediator = null;
		private readonly IContactRepository _repository = null;
		private readonly IWebHostEnvironment _webHostEnvironement = null;
		#endregion//Fields

		#region Constructors
		public ContactsController(IMediator mediator, IContactRepository repository, IWebHostEnvironment webHostEnvironement)
		{
			this._mediator = mediator;
			this._repository = repository;
			this._webHostEnvironement = webHostEnvironement;
		}
		#endregion//Constructors

		#region Public methods
		[HttpPost]
		public async Task<IActionResult> AddOne(ContactDTO contactDto)
		{
			IActionResult result = this.BadRequest();

			var contactResult = await this._mediator.Send(new AddContactCommand() { ContactDto = contactDto });
			if (contactResult != null)
			{
				result = this.Ok(contactResult);
			}

			return result;
		}

		[HttpPatch]
		public async Task<IActionResult> UpdateOne(string contactEmail, ContactDTO updatedContact)
		{
			IActionResult result = this.BadRequest();

			var contactResult = await this._mediator.Send(new UpdateContactCommand()
			{
				ContactEmail = contactEmail,
				ContactDto = updatedContact
			});

			if (contactResult != null)
			{
				result = this.Ok(contactResult);
			}

			return result;
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteOne(string contactEmail)
		{
			IActionResult result = this.BadRequest();

			var skillResult = await this._mediator.Send(new DeleteContactCommand() { ContactEmail = contactEmail });
			if (skillResult != null)
			{
				result = this.Ok(skillResult);
			}

			return result;
		}

		[HttpGet]
		//[EnableCors(SecurityMethods.DEFAULT_POLICY_3)]
		public IActionResult GetAll()
		{
			var model = this._mediator.Send(new SelectAllContactsQuery());

			return this.Ok(model);
		}

		[HttpGet]
		[Route("GetByEmail")]
		//[EnableCors(SecurityMethods.DEFAULT_POLICY_3)]
		public IActionResult GetByEmail([FromQuery] string email = "")
		{
			var model = this._mediator.Send(new SelectContactsByEmailQuery() { ContactEmail = email });

			return this.Ok(model);
		}
		#endregion//Public methods
	}
}
