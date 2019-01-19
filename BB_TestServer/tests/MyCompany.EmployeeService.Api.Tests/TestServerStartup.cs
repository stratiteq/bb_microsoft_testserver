using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.EmployeeService.Api.Implementations;

namespace MyCompany.EmployeeService.Api.Tests
{
    public class TestServerStartup : Startup
    {
        public TestServerStartup(Microsoft.Extensions.Configuration.IConfiguration configuration) : base(configuration)
        {
        }

        public override void RegisterThirdpartyDependencies(IServiceCollection services)
        {
            services.AddSingleton<IHumanusResursus, FakeHumanusResursus>();
        }
    }
}
