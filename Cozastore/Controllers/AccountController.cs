using System.Net.Mail;
using CozaStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Cozastore.Controllers;
public class AccountController : Controller
{
     private readonly ILogger<AccountController> _logger;
     private readonly SignInManager<IdentityUser> _signInManager;
     private readonly UserManager<IdentityUser> _UserManager;

    public AccountController(ILogger<AccountController> logger,  SignInManager<IdentityUser>signInManager, UserManager<IdentityUser> UserManager )
    {
        _logger = logger;
        _signInManager = signInManager;
        _UserManager = UserManager;
    }

    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
           LoginVM login = new()
           {
               UrlRetorno = returnUrl ?? Url.Content("~/")
           };
            return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM login)
    {
        if (ModelState.IsValid)
        {
            string userName = login.Email;
            if (IsValidEmail(userName))
            {
                var user = await _UserManager.FindByEmailAsync(userName);
                if (user != null)
                    userName = user.UserName;
            }

            var result = await _signInManager.PasswordSignInAsync(
                userName, login.Senha, login.Lembrar, lockoutOnFailure: true 
            );

            if (result.Succeeded)
            {
                _logger.LogInformation($"Usuario {login.Email} acessou o sistema!");
                return LocalRedirect(login.UrlRetorno);
            }

            if (result.IsLockedOut) 
            {
                _logger.LogWarning($"Usuário {login.Email} está bloqueado!");
                ModelState.AddModelError(string.Empty, "Conta bloqueada! Aguarde alguns minutos para continuar!");
            }

            ModelState.AddModelError(string.Empty, "Usuário e/ou Senha Inválidos!!!");

        }
        return View(login);
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            MailAddress mail = new(email);
            return true;
        }
        catch
        {
            return false;
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
     public IActionResult Error()
     {
            return View("Error!");
     }
}
