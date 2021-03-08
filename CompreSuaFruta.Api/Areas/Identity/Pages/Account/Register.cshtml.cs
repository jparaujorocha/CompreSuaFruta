using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CompreSuaFruta.Business.Interface;
using CompreSuaFruta.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CompreSuaFruta.Api.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IUsuarioBll _usuarioBll;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IUsuarioBll usuarioBll)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _usuarioBll = usuarioBll;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "CPF")]
            public string Cpf { get; set; }

            [Required]
            [Display(Name = "Nome")]
            public string Nome { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirme a senha")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            List<ProdutoCarrinho> itensCarrinho = new List<ProdutoCarrinho>();
            if (TempData["itensCarrinho"] != null)
            {
                itensCarrinho = JsonConvert.DeserializeObject<List<ProdutoCarrinho>>((string)TempData["itensCarrinho"]);
                if (itensCarrinho != null && itensCarrinho.Count > 0)
                {
                    ViewData["itensCarrinho"] = itensCarrinho;
                    ViewData["numeroItens"] = itensCarrinho.Count();
                }
                else
                {
                    ViewData["itensCarrinho"] = null;
                    ViewData["numeroItens"] = 0;
                }
            }
            else
            {
                ViewData["itensCarrinho"] = null;
                ViewData["numeroItens"] = 0;
            }

            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.Cpf };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    Usuario dadosUsuario = new Usuario();
                    dadosUsuario.Cpf = Input.Cpf;
                    dadosUsuario.Nome = Input.Nome;
                    dadosUsuario.Senha = Input.Password;
                    
                    _usuarioBll.InserirUsuario(dadosUsuario);

                    _logger.LogInformation("Usuário criado com sucesso.");

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
