using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace T2_DIARS_Pokemon.Models
{
    public class Entrenador
    {

        public int idEntrenador { get; set; }

        [Required(ErrorMessage = "El campo correo es requerido.")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "El campo contraseña como mínimo debe contener al menos 6 caracteres.")]
        [MinLength(6)]
        public string pass { get; set; }

        public List<EntrenadorPokemon> entrenadorPokemones { get; set; }

    }
}
