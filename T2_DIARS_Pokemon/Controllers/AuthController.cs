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
        private readonly IConfiguration configuration;

        public AuthController(PokemonContext _context, IConfiguration _configuration) {

             this.context = _context;
             this.configuration= _configuration;

        }

        public string LoggedUser() {

            var claims = HttpContext.User.Claims.FirstOrDefault();
            var user = context.entrenadores.Where(o => o.nombreUsuario == claims.Value).FirstOrDefault();

            return "el usuario logueado es " + user.idEntrenador;
        
        }


        public string Index(string input) {

            return CreateHash (input);

        }


        [HttpGet]

        public IActionResult Login() {

            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string pass) {

            var user = context.entrenadores
                .Where(o => o.nombreUsuario == usuario && o.passUsuario == CreateHash(pass))
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

        private string CreateHash(String input) {

            var sha = SHA256.Create();
            input = input + configuration.GetValue<string>("Token"); 
            var hash = sha.ComputeHash(Encoding.Default.GetBytes(input));

            return Convert.ToBase64String(hash);

        }
    }
}
