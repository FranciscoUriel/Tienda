using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Tienda.Persistence.DBContext;
using Tienda.Persistence.Entities;

namespace Tienda.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Usuarios> _signInManager;
        private readonly UserManager<Usuarios> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly TiendaContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(UserManager<Usuarios> userManager, SignInManager<Usuarios> signInManager,
            ILogger<RegisterModel> logger, IEmailSender emailSender,TiendaContext context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
            _roleManager = roleManager;
        }
        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

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
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }
        public async Task<IActionResult> OnPostAsync(
       string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new Usuarios
                {
                    FirsName = Input.FirstName,
                    LastName = Input.LastName,
                    UserName = Input.Email,
                    Email = Input.Email,
                    EmailConfirmed = true,
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    var car = new Carrito();
                    car.Fecha = DateTime.Now;
                    car.Vendido = false;
                    car.Usuario = await _userManager.FindByNameAsync(user.UserName);
                    _logger.LogInformation("User created a new account with password.");
                    await _context.Carritos.AddAsync(car);
                    await _context.SaveChangesAsync();
                    
                    if (await _roleManager.RoleExistsAsync("Cliente") == false)
                    {
                        IdentityRole identityRole = new IdentityRole();
                        identityRole.Name = "Cliente";
                        await _roleManager.CreateAsync(identityRole);
                    }
                    await _userManager.AddToRoleAsync(user, "Cliente");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
