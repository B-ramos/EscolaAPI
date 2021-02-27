using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.AulaConexao.Domain;
using System.Collections.Generic;


namespace AulaConexao.Data.Map
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.HasData(new List<Aluno>() {
                new Aluno(1, "Bruno", true),
                new Aluno(2, "Fabio", true),
                new Aluno(3, "Renata", true),
                new Aluno(4, "Camila", true),
                new Aluno(5, "Fernado", true),
                new Aluno(6, "Luan", true),
            });
            

            
        }
    }
}
