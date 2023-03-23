using KSAA.User.Application.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace KSAA.UserInterface.Web.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class Response<T>
    {
        public T Data { get; set; }
    }
    public class AuthenticationResponse
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //public string UserStatus { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }

    public class ErrorResponse
    {
        public ErrorResponse(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
        public List<ErrorModel> Errors { get; set; }
    }
}
