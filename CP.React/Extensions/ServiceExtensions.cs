using CP.BLL.Profiles;
using CP.BLL.Services;
using CP.BLL.Validators;
using CP.DAL;
using CP.DAL.Repositories;
using CP.DAL.UnitOfWork;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

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

        #region FIRST PARTY
        public static void AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<CarePlannerContext>(
                o => o.UseSqlServer(Configuration.GetSection("Development").GetConnectionString("CarePlannerDb"),
                x => x.MigrationsAssembly("CP.DAL")));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
        #endregion

        #region THIRD PARTY
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MapProfile)));
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new OpenApiInfo { Title = "CP API", Version = "v1" });
            });
        }

        public static void AddFluentValidation(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddFluentValidation(
                x => x.RegisterValidatorsFromAssemblyContaining<TeamDtoValidator>());

            ValidatorOptions.Global.LanguageManager.Enabled = false;
        }
        #endregion
    }
}
