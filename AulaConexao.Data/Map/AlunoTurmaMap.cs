using AulaConexao.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace AulaConexao.Data.Map
{
    public class AlunoTurmaMap : IEntityTypeConfiguration<AlunoTurma>
    {
        public void Configure(EntityTypeBuilder<AlunoTurma> builder)
        {
            builder.ToTable("AlunoTurma");            

            builder.HasKey(at => new { at.AlunpId, at.TurmaId });

            builder.HasOne(a => a.Turma)
                .WithMany(at => at.AlunosTurmas)
                .HasForeignKey(a => a.TurmaId);

            builder.HasOne(t => t.Aluno)
               .WithMany(at => at.AlunosTurmas)
               .HasForeignKey(t => t.AlunpId);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.HasData(new List<AlunoTurma>() {
                new AlunoTurma(1, 1, 1),
                new AlunoTurma(2, 2, 1),
                new AlunoTurma(3, 3, 1),
                new AlunoTurma(4, 4, 2),
                new AlunoTurma(5, 5, 2),
                new AlunoTurma(6, 6, 2),
            });
        }
    }
}
