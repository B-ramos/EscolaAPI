using AulaConexao.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AulaConexao.Data.Repository
{
    public class AlunoTurmaRepository
    {
        private readonly Context context;
        public AlunoTurmaRepository()
        {
            context = new Context();
        }


        public void Post(AlunoTurma alunoTurma)
        {
            context.Add(alunoTurma);
            context.SaveChanges();
        }

        public AlunoTurma GetById(int id)
        {
            IQueryable<AlunoTurma> query = context.AlunosTurmas;

            var aluno = query.Include(at => at.Turma)
                             .Include(at => at.Aluno)
                             .ToList();

            return aluno.FirstOrDefault(a => a.Id == id);
        }

        public List<AlunoTurma> GetAll()
        {
            IQueryable<AlunoTurma> query = context.AlunosTurmas;

            return query
                .Include(at => at.Aluno)
                .Include(at => at.Turma)
                .ToList();
                      
        }

        public bool Update(int id, AlunoTurma alunoTurma)
        {
            TurmaProfessor query = context.TurmasProfessores.AsNoTracking().FirstOrDefault(a => a.Id == id);

            if (query == null || alunoTurma.Id != id)
                return false;

            context.AlunosTurmas.Update(alunoTurma);
            context.SaveChanges();
            return true;
        }

        public void Delete(AlunoTurma alunoTurma)
        {
            context.AlunosTurmas.Remove(alunoTurma);
            context.SaveChanges();
        }
    }
}
