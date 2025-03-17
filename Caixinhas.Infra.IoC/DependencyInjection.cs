
using Caixinhas.Application.Interfaces;
using Caixinhas.Application.Mappings;
using Caixinhas.Application.Services;

using Caixinhas.Domain.Interfaces;
using Caixinhas.Infra.Data.Context;
using Caixinhas.Infra.Data.Identity;
using Caixinhas.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace Caixinhas.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
                     options.AccessDeniedPath = "/Account/Login");

            services.AddScoped<ICaixaLancamentoRepository, CaixaLancamentoRepository>();
            services.AddScoped<ICaixaRepository, CaixaRepository>();
            services.AddScoped<ICaixaLancamentoService, CaixaLancamentoService>();
            services.AddScoped<ICaixaService, CaixaService>();

            //services.AddScoped<IAuthenticate, AuthenticateService>();
            //services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //var myhandlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");
            //services.AddMediatR(myhandlers);

            return services;
        }
    }
}
