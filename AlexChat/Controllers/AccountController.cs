using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlexChatServices.ViewModels;
using AlexChatRepo.Entities;
using Microsoft.AspNetCore.Identity;
using AlexChat.Utils;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Text;
using System.IO;

namespace AlexChat.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMemoryCache _memoryCache;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IMemoryCache memoryCache)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._memoryCache = memoryCache;
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
        [Route("getrsakeys")]
        public IActionResult GetRSAKeys([FromBody] RegisterModel model)
        {
            var csp = new RSACryptoServiceProvider(1024);
            var pubKey = new StringBuilder(); 
            var privKey = csp.ExportParameters(true);
            _memoryCache.Set(model.Email, privKey);
            using(var outputStream = new StringWriter(pubKey))
            {
                RSAUtils.ExportPublicKey(csp, outputStream);
            }
            return new OkObjectResult(pubKey.ToString());
        }

        [HttpPost]
        [Route("register")]
        public async Task<string> Register([FromBody] RegisterModel model)
        {
            User user = new User { Email = model.Email, UserName = model.Email };
           
            var csp = new RSACryptoServiceProvider();
            var privKey = _memoryCache.Get<RSAParameters>(model.Email);
            csp.ImportParameters(privKey);
            
            var pass = Convert.FromBase64String(model.Password);
            var decryptedPassword = csp.Decrypt(pass, false);

            var result = await _userManager.CreateAsync(user, Encoding.Default.GetString(decryptedPassword));
            
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
        
        [Route("logout")]
        public async void Logout()
        {
            await _signInManager.SignOutAsync();
        }

       
    }
}