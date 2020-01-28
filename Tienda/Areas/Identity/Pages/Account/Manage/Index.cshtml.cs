using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tienda.Persistence.Entities;

namespace Tienda.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<Usuarios> _userManager;
        private readonly SignInManager<Usuarios> _signInManager;
        private readonly IEmailSender _emailSender;

        public IndexModel(UserManager<Usuarios> userManager, SignInManager<Usuarios> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }


        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"No se puede cargar la informacion del usuario con el ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Email = email,
                PhoneNumber = phoneNumber,
                FirstName = user.FirsName,
                LastName = user.LastName,
            };
            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"No se puede cargar la informacion del usuario con el ID '{_userManager.GetUserId(User)}'.");
            }
            user.FirsName = Input.FirstName;
            user.LastName = Input.LastName;
            await _userManager.UpdateAsync(user);

            var email = await _userManager.GetEmailAsync(user);
            if(Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user,Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Se produjo un error inesperado al asignar el email al usuario con el ID '{userId}'. ");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if(Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Se produjo un error inesperado al asignar el telefono al usuario con el ID '{userId}'. ");
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Se a actualizado tu perfil";
            return RedirectToPage();
        }
    }
}
