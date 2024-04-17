using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talakado.Domain.Users;
using Talakado.Web.Models.User;
using Talakado.Web.Utilities.Filters;

namespace Talakado.Web.Controllers
{
    [ServiceFilter(typeof(SaveVisitorFilter))]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public IActionResult Login(string ReturnUrl="/")
        {
            return View(new LoginViewModel
            {
                ReturnUrl = ReturnUrl,
            });
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid){ return View(model); }
            var user = _userManager.FindByNameAsync(model.Email).Result;
            if(user == null)
            {
                ModelState.AddModelError("", "کاربر یافت نشد");
                return View(model);
            }

            _signInManager.SignOutAsync();
            var login = _signInManager.PasswordSignInAsync(user, model.Password, model.IsPersistent, true).Result;
            if (login.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }

            ModelState.AddModelError("", "لاگین موفقیت آمیز نبود");
            return View(model);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            User newUser = new User
            {
                Email = model.Email,
                UserName = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
            };
            var register = _userManager.CreateAsync(newUser, model.Password);
            if(register.Result.Succeeded)
            {
                return RedirectToAction(nameof(Profile));
            }

            foreach (var item in register.Result.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);
            }
            return View(model);
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
