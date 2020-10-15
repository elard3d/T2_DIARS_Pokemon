using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using T2_DIARS_Pokemon.Models;

namespace T2_DIARS_Pokemon.Controllers
{
    public class AuthController : Controller
    {


        private PokemonContext context;

        public AuthController(PokemonContext _context) {

            context = _context;
        }


        [HttpGet]

        public IActionResult Login() {

            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string pass) {

            var user = context.entrenadores
                .Where(o => o.nombreUsuario == usuario && o.passUsuario== pass)
                .FirstOrDefault();

            if(user != null)
            {

                    var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, usuario)
                };


                    var clainmsIdentity = new ClaimsIdentity(claims, "Login");
                    var clainmsPrincipal = new ClaimsPrincipal(clainmsIdentity);

                    HttpContext.SignInAsync(clainmsPrincipal);

                    return RedirectToAction("Index", "Home");
               
            }

            ModelState.AddModelError("Login", "Usuario o contraseña incorrecto");
            return View();

        }

        [HttpGet]

        public IActionResult Logout() {

            HttpContext.SignOutAsync();
            return RedirectToAction("Login");

        }


    }
}
