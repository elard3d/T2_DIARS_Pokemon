using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T2_DIARS_Pokemon.Models;

namespace T2_DIARS_Pokemon.Controllers
{
    public class CapturarController : Controller
    {

        private readonly PokemonContext context;

        public CapturarController(PokemonContext _context)
        {
            context = _context;
        }

        public PokemonContext Context { get; }

        public IActionResult Index()
        {
            return View();
        }
    }
}
