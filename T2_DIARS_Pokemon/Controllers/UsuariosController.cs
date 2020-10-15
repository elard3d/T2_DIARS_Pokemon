using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using T2_DIARS_Pokemon.Models;

namespace T2_DIARS_Pokemon.Controllers
{
    public class UsuariosController : Controller
    {

        public PokemonContext _contex;

        public UsuariosController(PokemonContext master) {
            this._contex = master;
        }


        [HttpPost]
        public IActionResult Login( string usuario, string pass )
        {

            var usuarioConectado = _contex.entrenadores.Where(s=>s.usuario == usuario && s.pass == pass);

            if(usuarioConectado.Any())
            {
                if (usuarioConectado.Where(s => s.usuario == usuario && s.pass == pass).Any())
                {
                    return Json(new{status = true, message = "Bienvenido"});
                }
                else
                {
                    return Json(new { status = true, message = " Contraseña Incorrecto" });
                }
            }
            else
            {
                return Json(new { status = true, message = "Usuario Incorrecto" });
            }

            return View();
        }
    }
}
