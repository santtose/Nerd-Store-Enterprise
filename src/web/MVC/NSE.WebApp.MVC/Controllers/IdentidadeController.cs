using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class IdentidadeController : Controller
    {
        private readonly IAutenticacaoService _autentcacaoService;

        public IdentidadeController(IAutenticacaoService autentcacaoService)
        {
            _autentcacaoService = autentcacaoService;
        }

        [HttpGet]
        [Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return View(usuarioRegistro);

            var resposta = await _autentcacaoService.Registro(usuarioRegistro);

            if (false) return View(usuarioRegistro);

            return RedirectToAction("Index", "Home");

            //var resposta = await _autenticacaoService.Registro(usuarioRegistro);

            //if (ResponsePossuiErros(resposta.ResponseResult)) return View(usuarioRegistro);

            //await RealizarLogin(resposta);

            //return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            //ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {
            //ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid) return View(usuarioLogin);

            var resposta = await _autentcacaoService.Login(usuarioLogin);

            if (false) return View(usuarioLogin);

            return RedirectToAction("Index", "Home");

            //var resposta = await _autenticacaoService.Login(usuarioLogin);

            //if (ResponsePossuiErros(resposta.ResponseResult)) return View(usuarioLogin);

            //await RealizarLogin(resposta);

            //if (string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home");

            //return LocalRedirect(returnUrl);
        }

        [HttpGet]
        [Route("sair")]
        public async Task<IActionResult> Logout()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        //private async Task RealizarLogin(UsuarioRespostaLogin resposta)
        //{
        //    var token = ObterTokenFormatado(resposta.AccessToken);

        //    var claims = new List<Claim>();
        //    claims.Add(new Claim("JWT", resposta.AccessToken));
        //    claims.AddRange(token.Claims);

        //    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //    var authProperties = new AuthenticationProperties
        //    {
        //        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
        //        IsPersistent = true
        //    };

        //    await HttpContext.SignInAsync(
        //        CookieAuthenticationDefaults.AuthenticationScheme,
        //        new ClaimsPrincipal(claimsIdentity),
        //        authProperties);
        //}

        //private static JwtSecurityToken ObterTokenFormatado(string jwtToken)
        //{
        //    return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        //}
    }
}
