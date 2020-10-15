using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using T2_DIARS_Pokemon.Models;

namespace T2_DIARS_Pokemon.Controllers
{
    public class entrenadorPokemonController : Controller
    {
        
        public class EntrenadorPokemonController : Controller
        {

            private PokemonContext conexion;
            public IHostEnvironment _hostEnviroment;


            public EntrenadorPokemonController(PokemonContext _conexion, IHostEnvironment _configuration)
            {
                conexion = _conexion;
                _hostEnviroment = _configuration;
            }

            public ActionResult Index(int idEntrenador)
            {
                return View(conexion.entrenadorPokemones.Where(o => o.idEntrenador == idEntrenador).Include(o => o.pokemon).ToList());
            }



            public ActionResult Create(int idPokemon)
            {

                EntrenadorPokemon pokemonCapturado = new EntrenadorPokemon();

                pokemonCapturado.fechaCaptura = DateTime.Now;
                var claim = HttpContext.User.Claims.FirstOrDefault();
                var user = conexion.entrenadores.Where(o => o.nombreUsuario== claim.Value).FirstOrDefault();

                pokemonCapturado.idEntrenador = user.idEntrenador;
                pokemonCapturado.idPokemon = idPokemon;
                conexion.entrenadorPokemones.Add(pokemonCapturado);
                conexion.SaveChanges();
                return RedirectToAction("Index", "Pokemon");
            }

            public ActionResult Delete(int id)
            {
                var x = conexion.entrenadorPokemones.Where(o => o.idEntrenadorPokemon == id).FirstOrDefault();

                conexion.Remove(x);
                conexion.SaveChanges();

                return RedirectToAction("Index", "Pokemon");


                }
            }
       }
    }
