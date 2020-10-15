using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T2_DIARS_Pokemon.Models.Maps
{
    public class EntrenadorPokemonMap: IEntityTypeConfiguration <EntrenadorPokemon>
    {
        public void Configure(EntityTypeBuilder<EntrenadorPokemon> builder)
        {
            builder.ToTable("EntrenadorPokemon");
            builder.HasKey(o => o.idEntrenadorPokemon);

            builder.HasOne(o => o.entrenador).WithMany(o => o.entrenadorPokemones).HasForeignKey(o => o.idEntrenador);
            builder.HasOne(o => o.pokemon).WithMany().HasForeignKey(o => o.idPokemon);


        }
    }
}
