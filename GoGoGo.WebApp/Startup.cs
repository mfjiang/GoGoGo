using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace GoGoGo.WebApp
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
			services.AddMvc()
				.AddMvcOptions(options=> {
					options.EnableEndpointRouting = false;
				})
				.AddJsonOptions(options =>
				{
					options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
					options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
#if DEBUG
					options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Error;
#else
					options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
#endif
				})
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddSpaStaticFiles(config => config.RootPath = "ClientApp/dist");

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
			});
			

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();

			app.UseSpaStaticFiles();

			app.UseMvcWithDefaultRoute();

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
			});

			app.UseSpa(b =>
			{
				if (env.IsDevelopment())
				{
#if DEBUG
					// 注释下面这行，如果没有启动前端
					// b.UseProxyToSpaDevelopmentServer("http://localhost:8080");
#endif
				}
			});

		}
	}
}
