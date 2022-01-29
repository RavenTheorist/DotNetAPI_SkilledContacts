﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Core.Skills.Infrastructure.Data
{
	public class SkillsContextFactory : IDesignTimeDbContextFactory<SkillsContext>
	{
		#region Public methods
		public SkillsContext CreateDbContext(string[] args)
		{
			// Build a configuration to be able to access our appSettings.json
			ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

			// Set our custom json file path
			configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Settings", "appSettings.json"));

			// Build the JSon file into a dictionary to be able to access its data more easily using a IConfigurationRoot
			IConfigurationRoot configurationRoot = configurationBuilder.Build();
			
			// Create a DbContextOptions, to be able to pass some options to our context
			DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

			// Set the DB provider
			builder.UseSqlServer(configurationRoot.GetConnectionString("SkillsDatabase"), b => b.MigrationsAssembly("Contacts.Core.Skills.Data.Migrations"));

			SkillsContext context = new SkillsContext(builder.Options);

			return context;
		}
		#endregion//Public methods
	}
}
