using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2_DIARS_Pokemon.Models.Maps;

namespace T2_DIARS_Pokemon.Models
{
    public class PokemonContext: DbContext
    {


        public DbSet<Pokemon> pokemones { get; set; }

        public virtual DbSet<Entrenador> entrenadores { get; set; }

        public DbSet<EntrenadorPokemon> entrenadorPokemones { get; set; }

        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PokemonMap());
            modelBuilder.ApplyConfiguration(new EntrenadorMap());
            modelBuilder.ApplyConfiguration(new EntrenadorPokemonMap());
        }



    }
}
