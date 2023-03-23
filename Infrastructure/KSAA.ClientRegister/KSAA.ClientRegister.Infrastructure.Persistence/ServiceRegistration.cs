using KSAA.DAL.Repositories;
using KSAA.DAL;
using KSAA.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using KSAA.ClientRegister.Infrastructure.Shared.Services;
using KSAA.ClientRegister.Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace KSAA.ClientRegister.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("MSSQLConnection");
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));
            
            services.AddScoped<IClientAuthorizedSignatoryService, ClientAuthorizedSignatoryService>();
            services.AddScoped<IClientBankAccountService, ClientBankAccountService>();
            services.AddScoped<IClientManagingDirectorService, ClientManagingDirectorService>();
            services.AddScoped<IClientRegistrationService, ClientRegistrationService>();
            services.AddScoped<IClientServicesGoodsService, ClientServicesGoodsService>();

            #region Repositories

            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            
            #endregion Repositories
        }
    }
}