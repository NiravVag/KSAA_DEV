namespace KSAA.ClientRegister.ApiServices.Controllers.Extensions
{
    public static class JwtTokenConfig
    {
        public static IServiceCollection AddJwtTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}