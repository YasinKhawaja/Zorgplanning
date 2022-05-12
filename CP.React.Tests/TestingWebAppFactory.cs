using CP.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CP.React.Tests
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<CarePlannerContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<CarePlannerContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryCarePlannerTestDb");
                });

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();

                using var appContext = scope.ServiceProvider.GetRequiredService<CarePlannerContext>();

                try
                {
                    if (appContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                    {
                        appContext.Database.Migrate();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            });
        }
    }
}
