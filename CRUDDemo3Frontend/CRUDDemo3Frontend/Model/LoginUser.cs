using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CRUDDemo3Frontend.Model
{
    public class LoginUser 
    {
        
        public string EmailAddress { get; set; }

        
        public string Password { get; set; }
    }
}
