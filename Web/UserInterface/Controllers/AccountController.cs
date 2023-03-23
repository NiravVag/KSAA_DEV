using KSAA.UserInterface.Web.Models.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IdentityModel.Client;

namespace KSAA.UserInterface.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var httpClient = new HttpClient();

            var httpResponse = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = _configuration["AuthServer:Url"] + "connect/token",
                ClientId = _configuration["AuthServer:ClientId"],
                ClientSecret = _configuration["AuthServer:ClientSecret"],
                UserName = model.Email,
                Password = model.Password
            });
            if (!httpResponse.IsError)
            {
                var userResponse = await httpClient.GetUserInfoAsync(new UserInfoRequest()
                {
                    Address = _configuration["AuthServer:Url"] + "connect/userinfo",
                    Token = httpResponse.AccessToken
                });
                var claims = new List<Claim>();
                claims.AddRange(userResponse.Claims);
                var roleClaim = claims.FirstOrDefault(x => x.Type == "role");
                if (roleClaim != null)
                    claims.Add(new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", roleClaim.Value));


                var claimsIdentity = new ClaimsIdentity(
                  claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return Ok();
            }
            else
            {
                return BadRequest(httpResponse.Json);
            }

        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
