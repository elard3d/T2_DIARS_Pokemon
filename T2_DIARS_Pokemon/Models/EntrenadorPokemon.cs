using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T2_DIARS_Pokemon.Models
{
    public class EntrenadorPokemon
    {

        public int idEntrenadorPokemon { get; set; }

        public DateTime fechaCaptura { get; set; }

        public int idEntrenador { get; set; }
        public int idPokemon { get; set; }


        public Pokemon pokemon { get; set; }
        public Entrenador entrenador { get; set; }

    }
}
