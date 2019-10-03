using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using WebDotNetCore;

namespace DotNetCore.Tests.Helper
{
    public class WebApplicationTestFactory : WebApplicationFactory<Startup>
    {
        private readonly string _relativePath;

        public WebApplicationTestFactory(string relativePath)
        {
            _relativePath = relativePath;
        }

        protected override IHostBuilder CreateHostBuilder()
        {
            var integrationTestsPath = PlatformServices.Default.Application.ApplicationBasePath;
            var applicationPath = Path.GetFullPath(Path.Combine(integrationTestsPath, _relativePath));
            return Program.CreateGenericHostBuilder<Startup>(applicationPath, true);
        }
    }
}
