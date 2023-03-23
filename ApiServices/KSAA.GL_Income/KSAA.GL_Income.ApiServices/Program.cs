using KSAA.GL_Income.ApiServices.Controllers.Extensions;
using KSAA.GL_Income.ApiServices.Controllers.Middlewares;
using KSAA.GL_Income.Application;
using KSAA.GL_Income.Application.Interfaces.Repositories;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Infrastructure.Persistence;
using KSAA.GL_Income.Infrastructure.Persistence.Repositories;
using KSAA.GL_Income.Infrastructure.Shared.Services;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddScoped<IGLIncomeRepositoryAsync, GLIncomeRepositoryAsync>();
builder.Services.AddScoped<IGLIncomeService, GLIncomeService>();
builder.Services.AddScoped<IOutputLiabilityService, OutputLiabilityService>();
builder.Services.AddScoped<IOutputLiabilityRepositoryAsync, OutputLiabilityRepositoryAsync>();
builder.Services.AddScoped<IComparisonReportService, ComparisonReportService>();
builder.Services.AddScoped<IComparisonReportRepositoryAsync, ComparisonReportRepositoryAsync>();
builder.Services.AddScoped<IOutputRegisterRepositoryAsync, OutputRegisterRepositoryAsync>();
builder.Services.AddScoped<IAdvanceAdjustmentRepositoryAsync, AdvanceAdjustmentRepositoryAsync>();
builder.Services.AddScoped<IAdvanceAdjustmentService, AdvanceAdjustmentService>();
builder.Services.AddScoped<IFinalOutputRegisterService, FinalOutputRegisterService>();
builder.Services.AddScoped<IFinalOutputRegisterRepositoryAsync, FinalOutputRegisterRepositoryAsync>();

builder.Services.AddJwtTokenAuthentication(builder.Configuration);
builder.Services.AddApiVersioningExtension();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer().AddApplicationLayer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var enUsCulture = new CultureInfo("en-GB");
var localizationOptions = new RequestLocalizationOptions()
{
    DefaultRequestCulture = new RequestCulture(enUsCulture)
};

app.UseRequestLocalization(localizationOptions);

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
