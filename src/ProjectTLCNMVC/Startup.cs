using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProjectTLCNMVC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.IO;

namespace ProjectTLCNMVC
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();

			if (env.IsDevelopment())
			{
				// This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
				builder.AddApplicationInsightsSettings(developerMode: true);
			}
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// config database
			var connection = @"Server=.;Database=ProjectShopAPI;Trusted_Connection=True;";
			services.AddEntityFramework().AddDbContext<ProjectShopAPIContext>(options => options.UseSqlServer(connection));
			// Add framework services.
			services.AddApplicationInsightsTelemetry(Configuration);

			//services.AddIdentity<IdentityUser, IdentityRole>()
			//	.AddEntityFrameworkStores<ProjectShopAPIContext>()
			//	.AddDefaultTokenProviders();
			
			services.Configure<RazorViewEngineOptions>(options =>
			{
				options.AreaViewLocationFormats.Clear();
				options.AreaViewLocationFormats.Add("/Admin/{2}/Views/{1}/{0}.cshtml");
				options.AreaViewLocationFormats.Add("/Admin/{2}/Views/Shared/{0}.cshtml");
				options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
			}
			
		);
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();
			app.UseApplicationInsightsRequestTelemetry();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
				app.UseBrowserLink();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseApplicationInsightsExceptionTelemetry();

			app.UseDefaultFiles();
			app.UseStaticFiles();

			// Serve static files (html, css, js, images & more). See also the following URL:
			// https://docs.asp.net/en/latest/fundamentals/static-files.html for further reference.
			//app.UseStaticFiles(new StaticFileOptions()
			//{
			//	OnPrepareResponse = (context) =>
			//	{
			//		// Disable caching for all static files.
			//		context.Context.Response.Headers["Cache-Control"] = Configuration["StaticFiles:Headers:Cache-Control"];
			//		context.Context.Response.Headers["Pragma"] = Configuration["StaticFiles:Headers:Pragma"];
			//		context.Context.Response.Headers["Expires"] = Configuration["StaticFiles:Headers:Expires"];
			//	}
			//});
			//app.UseStaticFiles();
			//app.UseIdentity();
			//app.UseMvc();
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "areaRoute",
					template: "{area:exists}/{controller=Home}/{action=Index}");
				routes.MapRoute(
				   name: "default",
				   template: "{controller=Home}/{action=Index}/{id?}");

			});
		}
	}
}
