using AulaConexao.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AulaConexao.Data.Map
{
    public class TurmaProfessorMap : IEntityTypeConfiguration<TurmaProfessor>
    {
        public void Configure(EntityTypeBuilder<TurmaProfessor> builder)
        {
            builder.ToTable("TurmaProfessor");            

            builder.HasKey(tp => new { tp.TurmaId, tp.ProfessorId });

            builder.HasOne(t => t.Professor)
                .WithMany(tp => tp.TurmasProfessores)
                .HasForeignKey(t => t.ProfessorId);

            builder.HasOne(p => p.Turma)
               .WithMany(tp => tp.TurmasProfessores)
               .HasForeignKey(p => p.TurmaId);

            builder.Property(x => x.Id)
                .UseIdentityColumn();
        }
    }
}
