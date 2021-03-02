using AulaConexao.Data.Map;
using AulaConexao.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Models.AulaConexao.Domain;

namespace AulaConexao.Data
{
    public class Context : DbContext
    {      
        public DbSet<Aluno> Alunos { get; set; }        
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<TurmaProfessor> TurmasProfessores { get; set; }
        public DbSet<AlunoTurma> AlunosTurmas { get; set; }

        public Context(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());          
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new TurmaProfessorMap());
            modelBuilder.ApplyConfiguration(new AlunoTurmaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
