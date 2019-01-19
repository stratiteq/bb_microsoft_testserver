using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using MyCompany.EmployeeService.Api.Implementations;
using MyCompany.EmployeeService.Repositories;
using MyCompany.EmployeeService.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace MyCompany.EmployeeService.Api
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
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Employees API", Version = "v1" });

                var path = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath,  "MyCompany.EmployeeService.Api.xml");
                c.IncludeXmlComments(path);
            });

            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IEmployeeService, Services.EmployeeService>();

            RegisterThirdpartyDependencies(services);
        }

        public virtual void RegisterThirdpartyDependencies(IServiceCollection services)
        {
            services.AddSingleton<IHumanusResursus, HumanusResursus>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employees API");
            });
        }
    }
}
