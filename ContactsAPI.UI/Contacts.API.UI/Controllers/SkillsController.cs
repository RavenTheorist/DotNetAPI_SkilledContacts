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

namespace Contacts.API.UI.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[EnableCors(SecurityMethods.DEFAULT_POLICY)]
	public class SkillsController : ControllerBase
	{
		#region Fields
		private readonly IMediator _mediator = null;
		private readonly ISkillRepository _repository = null;
		private readonly IWebHostEnvironment _webHostEnvironement = null;
		#endregion//Fields

		#region Constructors
		public SkillsController(IMediator mediator, ISkillRepository repository, IWebHostEnvironment webHostEnvironement)
		{
			this._mediator = mediator;
			this._repository = repository;
			this._webHostEnvironement = webHostEnvironement;
		}
		#endregion//Constructors

		#region Public methods
		[HttpGet]
		//[EnableCors(SecurityMethods.DEFAULT_POLICY_3)]
		//[DisableCors]
		public IActionResult GetAll([FromQuery]string skillName = "")
		{
			//var model = Enumerable.Range(1, 10).Select(index => new Skill() { Id = index });
			//return this.StatusCode(StatusCodes.Status204NoContent);

			//var model = this._skillsContext.Skills.ToList();
			//var query = from skill in this._skillsContext.Skills
			//			join contact in this._skillsContext.Contacts on skill.Contact.Id equals contact.Id
			//			select skill;

			var param = this.Request.Query["userId"];

			var model = this._mediator.Send(new SelectAllSkillsQuery() { SkillName = skillName });

			return this.Ok(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddOne(SkillDTO skillDto)
		{
			IActionResult result = this.BadRequest();

			var skillResult = await this._mediator.Send(new AddSkillCommand() { SkillDto = skillDto });
			if (skillResult != null)
			{
				result = this.Ok(skillResult);
			}

			return result;
		}
		#endregion//Public methods
	}
}
