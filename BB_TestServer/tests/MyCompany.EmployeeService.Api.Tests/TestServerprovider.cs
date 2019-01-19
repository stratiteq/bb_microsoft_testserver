using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MyCompany.EmployeeService.Api.Tests
{
    public class TestServerprovider : IDisposable
    {
        public HttpClient Client { get; private set; }
        private TestServer server;

        public TestServerprovider()
        {
            server = new TestServer(new WebHostBuilder()
                .UseStartup<TestServerStartup>()
                .UseEnvironment("Development"));

            Client = server.CreateClient();
        }

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}
