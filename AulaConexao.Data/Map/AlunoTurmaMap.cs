using AulaConexao.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        }
    }
}
