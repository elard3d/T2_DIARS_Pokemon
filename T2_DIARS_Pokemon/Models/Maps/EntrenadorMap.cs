using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T2_DIARS_Pokemon.Models.Maps
{
    public class EntrenadorMap : IEntityTypeConfiguration <Entrenador>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entrenador> builder)
        {
            builder.ToTable("Entrenador");
            builder.HasKey(o => o.idEntrenador);

            builder.HasMany(o => o.entrenadorpokemons).WithOne(O => O.entrenador).HasForeignKey(o => o.idEntrenador);

        }
    }
}
