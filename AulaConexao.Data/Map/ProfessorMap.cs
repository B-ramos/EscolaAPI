using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.AulaConexao.Domain;
using System.Collections.Generic;

namespace AulaConexao.Data.Map
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professor");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.Email)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(x => x.Turno)
                .HasColumnType("varchar(50)");

            //builder.HasData(new List<Professor>() {
            //    new Professor(1, "Bruno", "Ramos@.com", 1),
            //    new Professor(2, "Fabio", "Nako@.com", 2),
            //    new Professor(3, "Renata", "Laura@.com", 3),
            //    new Professor(4, "Camila", "Farias@.com", 4),
            //});
        }
    }
}
