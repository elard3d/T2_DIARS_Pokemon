using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T2_DIARS_Pokemon.Models.Maps
{
    public class PokemonMap:IEntityTypeConfiguration <Pokemon>
    {
        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            builder.ToTable("Pokemon");
            builder.HasKey(o => o.idPokemon);
        }
    }
}
