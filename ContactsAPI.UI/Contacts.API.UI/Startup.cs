using Contacts.API.UI.ExtensionMethods;
using Contacts.API.UI.Middlewares;
using Contacts.Core.Skills.Domain;
using Contacts.Core.Skills.Infrastructure.Data;
using Contacts.Core.Skills.Infrastructure.Loggers;
using Contacts.Core.Skills.Infrastructure.Repositories;
using ContactsAPI.UI.ExtensionMethods;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.UI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<SkillsContext>(options =>
			{
				options.UseSqlServer(this.Configuration.GetConnectionString("SkillsDatabase"), sqlOption => { });
			});

			// Link the authentication identity to the DbContext
			services.AddDefaultIdentity<IdentityUser>(options =>
			{
				// Add some authentication params
				//options.SignIn.RequireConfirmedEmail = true;
				//options.Password.RequireDigit = true;
			}).AddEntityFrameworkStores<SkillsContext>();

			services.AddCustomOptions(this.Configuration);
			services.AddInjections()
					.AddCustomSecurity(this.Configuration);

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contacts.API.UI", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddProvider(new CustomLoggerProvider());

			app.UseCustomMiddlewares();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contacts.API.UI v1"));

			Console.WriteLine(env.WebRootPath);

			app.UseHttpsRedirection();

			app.UseRouting();

			// Enable Cors
			app.UseCors(SecurityMethods.DEFAULT_POLICY_2);

			// Enable Authentication for JWT
			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
