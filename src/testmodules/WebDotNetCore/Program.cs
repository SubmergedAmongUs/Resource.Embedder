using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace WebDotNetCore
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(params string[] args)
            => CreateGenericHostBuilder<Startup>(null, false, args);

        /// <summary>
        /// Indirection for integration tests. Allows override with custom class that inherits Startup
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateGenericHostBuilder<T>(string rootPath, bool devTest, params string[] args) where T : Startup
        {
            var hostBuilder = Host
                .CreateDefaultBuilder(args);
            if (devTest)
                hostBuilder.UseEnvironment("Development");

            hostBuilder
                .ConfigureWebHostDefaults(builder =>
                {
                    builder
                    .UseContentRoot(rootPath ?? Directory.GetCurrentDirectory())
                    .UseStartup<T>();
                });

            return hostBuilder;
        }
    }
}
