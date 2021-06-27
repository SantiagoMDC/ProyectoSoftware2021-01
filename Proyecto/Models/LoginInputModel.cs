using System.ComponentModel.DataAnnotations;

using Entity;
using System;
namespace Proyecto.Models
{
    public class LoginInputModel
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Estado { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Token { get; set; }
        
    }

    public class LoginViewModel : LoginInputModel
    {
        public LoginViewModel()
        {

        }
        public LoginViewModel(User user)
        {   
            UserName = user.UserName;
            Password = user.Password;
            Estado = user.Estado;
            FirstName = user.Estado;
            LastName = user.LastName;
            Email = user.Email;
            MobilePhone = user.MobilePhone;
            Token = user.Token;
        }
    }
}