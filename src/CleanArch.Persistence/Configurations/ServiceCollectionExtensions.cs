using CleanArch.Domain.Interfaces;
using CleanArch.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Persistence.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddDbContext<FuncionarioDbContext>(options =>
            //              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<FuncionarioDbContext>(options =>
               options.UseSqlite(configuration.GetConnectionString("Sqlite")));

            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

        }
    }
}
