using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlexChat.ViewModels;
using AlexChat.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace AlexChat.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        [Route("getUsername")]
        public string GetUsername()
        {
            return User.Identity.Name;
        }

        [HttpPost]
        [Route("login")]
        public async Task<string> Login([FromBody] RegisterModel model)
        {
            
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            
            if (result.Succeeded)
            {
                return model.Email;
            }
            else
            {
                return "_wronglogin_";
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<string> Register([FromBody] RegisterModel model)
        {
            
            User user = new User { Email = model.Email, UserName = model.Email };
            
            var result = await _userManager.CreateAsync(user, model.Password);
            
            if (result.Succeeded)
            {
                // установка куки
                await _signInManager.SignInAsync(user, true);
                return user.UserName;
            }
            else
            {
                return "_wrongregister_";
            }
        }

        [HttpGet]
        [Route("logout")]
        public async void Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}