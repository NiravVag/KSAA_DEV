using KSAA.ClientRegister.ApiServices.Controllers.Extensions;
using KSAA.ClientRegister.ApiServices.Controllers.Middlewares;
using KSAA.ClientRegister.Application;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.ClientRegister.Infrastructure.Persistence;
using KSAA.ClientRegister.Infrastructure.Shared.Services;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddScoped<IClientAuthorizedSignatoryService, ClientAuthorizedSignatoryService>();
builder.Services.AddScoped<IClientBankAccountService, ClientBankAccountService>();
builder.Services.AddScoped<IClientManagingDirectorService, ClientManagingDirectorService>();
builder.Services.AddScoped<IClientRegistrationService, ClientRegistrationService>();
builder.Services.AddScoped<IClientServicesGoodsService, ClientServicesGoodsService>();

builder.Services.AddJwtTokenAuthentication(builder.Configuration);
builder.Services.AddApiVersioningExtension();
//builder.Services.AddSwaggerConfiguration();

// Add services to the container.

builder.Services.AddControllers();
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
