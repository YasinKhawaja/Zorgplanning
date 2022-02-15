using CP.DAL;
using CP.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CP.React.Extensions
{
    public static class ServiceExtensions
    {
        static IConfiguration Configuration { get; }

        static ServiceExtensions()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddDbContext<CarePlannerContext>(
                o => o.UseSqlServer(Configuration.GetSection("Development").GetConnectionString("CarePlannerDb"),
                x => x.MigrationsAssembly("CP.DAL")));
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
