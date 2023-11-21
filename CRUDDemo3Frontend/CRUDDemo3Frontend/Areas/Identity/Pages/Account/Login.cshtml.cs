using CRUDDemo3Frontend.Model;
using CRUDDemo3Frontend.Service;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NLog;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CRUDDemo3Frontend.Areas.Identity.Pages.Account
{
    public class LoginModel2 : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserService _userService;
        public LoginModel2(SignInManager<IdentityUser> signInManager, IUserService userService)
        {
            _signInManager = signInManager;
            _userService = userService;
        }
        [BindProperty]
        public InputModel2 Input2 { get; set; }
        public string ReturnUrl { get; set; }
        public async Task OnGetAsync()
        {
            ReturnUrl = Url.Content("~/");
            ViewData["ErrorMessage"] = "";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await _userService.ValidateUser(new LoginUser() { EmailAddress = Input2.Email, Password = Input2.Password });
                if (result)
                {
                    IdentityUser identity = new IdentityUser() { UserName = Input2.Email, Email = Input2.Email };
                    await _signInManager.SignInAsync(identity, isPersistent: false);

                    return LocalRedirect(ReturnUrl);
                }
                else
                {
                    ViewData["ErrorMessage"] = "Wrong Email or Password";
                }               
            }

            return Page();
        }

        public class InputModel2
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
