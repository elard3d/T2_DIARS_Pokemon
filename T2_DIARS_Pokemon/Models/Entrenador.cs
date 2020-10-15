using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T2_DIARS_Pokemon.Models
{
    public class Entrenador
    {

        public int idEntrenador { get; set; }

        public string usuario { get; set; }
        public string passwd { get; set; }

        public List<EntrenadorPokemon> entrenadorPokemones { get; set; }

    }
}
