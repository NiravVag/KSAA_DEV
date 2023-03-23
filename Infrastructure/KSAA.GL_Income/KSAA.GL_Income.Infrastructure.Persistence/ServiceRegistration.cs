using KSAA.DAL;
using KSAA.DAL.Repositories;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.GL_Income.Application.Interfaces.Repositories;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Infrastructure.Persistence.Repositories;
using KSAA.GL_Income.Infrastructure.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("MSSQLConnection");
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IGLIncomeService, GLIncomeService>();
            services.AddScoped<IComparisonReportService, ComparisonReportService>();
            services.AddScoped<IAdvaceReceivedService, AdvaceReceivedService>();
            services.AddScoped<IOutputRegisterService, OutputRegisterService>();
            services.AddScoped<IAdvanceAdjustmentService, AdvanceAdjustmentService>();
            services.AddScoped<IFinalOutputRegisterService, FinalOutputRegisterService>();
            #region Repositories

            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddScoped<IGLIncomeRepositoryAsync, GLIncomeRepositoryAsync>();
            services.AddScoped<IAdvaceReceivedRepositoryAsync, AdvaceReceivedRepositoryAsync>();
            services.AddScoped<IAdvanceAdjustmentRepositoryAsync, AdvanceAdjustmentRepositoryAsync>();

            #endregion Repositories
        }
    }
}
