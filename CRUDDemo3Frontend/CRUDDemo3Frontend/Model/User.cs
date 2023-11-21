using System.ComponentModel.DataAnnotations;

namespace CRUDDemo3Frontend.Model
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "User ID")]
        public string UserID { get; set; }
        public string Password { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
}
