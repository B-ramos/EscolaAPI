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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=lostvdp;" +
                                        "Persist Security Info=True;" +
                                        "User ID=sa;" +
                                        "Initial Catalog=AulaConexao;" +
                                        "Data Source=DESKTOP-KU312JU\\SQLEXPRESS");

            base.OnConfiguring(optionsBuilder);
        }

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
