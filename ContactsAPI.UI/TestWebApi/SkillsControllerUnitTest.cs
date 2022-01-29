using Contacts.API.UI.Controllers;
using Contacts.Core.Framework;
using Contacts.Core.Skills.Domain;
using ContactsAPI.UI.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestWebApi
{
	public class SkillsControllerUnitTest
	{
		[Fact]
		public void ShouldAddOneSkill()
		{
			// ARRANGE
			//SkillDTO skillDto = new SkillDTO();
			//Mock<ISkillRepository> repositoryMock = new Mock<ISkillRepository>();
			//Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
			//repositoryMock.Setup(item => item.UnitOfWork).Returns(unitOfWork.Object);
			//repositoryMock.Setup(item => item.AddOne(It.IsAny<Skill>())).Returns(new Skill() { Id = 4 });

			//// ACT
			//var controller = new SkillsController(repositoryMock.Object);
			//IActionResult result = controller.AddOne(skillDto);

			//// ASSERT
			//Assert.NotNull(result);
			//Assert.IsType<OkObjectResult>(result);

			//SkillDTO addedSkill = (result as OkObjectResult).Value as SkillDTO;
			//Assert.NotNull(addedSkill);
			//Assert.True(addedSkill.Id > 0);
		}

		[Fact]
		public void TesterMaMethodeGet()
		{
			// ARRANGE
			//List<Skill> expectedSkillsList = new List<Skill>()
			//{
			//	new Skill() { Id = 1, Contact = new Contact() },
			//	new Skill() { Id = 2, Contact = new Contact() }
			//};

			//Mock<ISkillRepository> repositoryMock = new Mock<ISkillRepository>();
			//repositoryMock.Setup(item => item.GetAll(It.IsAny<int>())).Returns(expectedSkillsList);

			//SkillsController controller = new SkillsController(repositoryMock.Object);

			//// ACT
			//IActionResult result = controller.GetAll();

			//// ASSERT
			//Assert.NotNull(result);
			//Assert.IsType<OkObjectResult>(result);

			//OkObjectResult okResult = result as OkObjectResult;

			//Assert.NotNull(okResult.Value);
			//Assert.IsType<List<SkillResumeDTO>>(okResult.Value);

			//List<SkillResumeDTO> list = okResult.Value as List<SkillResumeDTO>;
			//Assert.True(list.Count == expectedSkillsList.Count);
		}
	}
}
