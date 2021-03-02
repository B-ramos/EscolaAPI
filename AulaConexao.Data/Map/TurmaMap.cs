using AulaConexao.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace AulaConexao.Data.Map
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turma");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(500)");

            //builder.HasData(new List<Turma>() {
            //    new Turma(1, "Asp.Net", "Curso Campinas Tech"),
            //    new Turma(2, "React", "Curso Udemy")                
            //});
        }
    }
}
