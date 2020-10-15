using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using T2_DIARS_Pokemon.Models;



namespace T2_DIARS_Pokemon.Controllers
{

    

    public class PokemonController : Controller
    {

        private PokemonContext _context;
        public IHostingEnvironment _hostEnvironment;

        public PokemonController(PokemonContext context,  IHostingEnvironment hostEnvironment)
        {

            _context = context;
            _hostEnvironment = hostEnvironment;

        }
        [Authorize]
        [HttpGet]
        public ViewResult Index()
        {

          ViewBag.Pokemons = _context.pokemones.ToList();

            return View("Index");
        }

        [HttpGet]
        public ViewResult Create()//GET
        {
            return View("Create");
        }


        [HttpPost]

        public ActionResult Create(Pokemon pokemon, IFormFile imagenPokemon)//POST
        {
           
            if (ModelState.IsValid)
            {

                if (imagenPokemon != null && imagenPokemon.Length > 0) {

                    var basePath = _hostEnvironment.ContentRootPath + @"\wwwroot";
                    var ruta = @"\img\" + imagenPokemon.FileName;
                     
                    using (var stream = new FileStream(basePath + ruta, FileMode.Create)) 
                    {
                        imagenPokemon.CopyTo(stream);
                        pokemon.imagenPokemon = ruta;
                    }

                }

                _context.pokemones.Add(pokemon);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            return View("Create", pokemon);

        }


        [HttpGet]

        public ActionResult Edit(int id)
        {

            ViewBag.Types = new List<string> { "Agua", "Fuego", "Planta" };

            ViewBag.Pokemon = _context.pokemones.Where(o => o.idPokemon == id).FirstOrDefault();

            return View("Edit");
        }

        [HttpPost]

        public ActionResult Edit(Pokemon pokemon)
        {

            _context.pokemones.Update(pokemon);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult Delete(int id)
        {

            var pokemon = _context.pokemones.Where(o => o.idPokemon == id).FirstOrDefault();

            _context.pokemones.Remove(pokemon);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Buscar(Pokemon pokemon, string nombre, string tipo)
        {

            var mostrar = _context.pokemones.Where(o => o.nombrePokemon == nombre || o.tipoPokemon == tipo)
                .ToList();
            if (mostrar != null)
            {
                return View(mostrar);
            }
            return View(pokemon);
        }

    }
}
