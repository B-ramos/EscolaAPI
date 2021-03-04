using AulaConexao.Data.Interface;
using AulaConexao.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Models.AulaConexao.Domain;
using SalaoCampinasTech.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AulaConexao.Data.Repository
{
    public class AlunoTurmaRepository : BaseRepository<AlunoTurma>, IAlunoTurmaRepository
    {
        public AlunoTurmaRepository(Context context) : base(context) { }

        public override List<AlunoTurma> FindAll()
        {
            IQueryable<AlunoTurma> query = _context.AlunosTurmas;

            return query
                .Include(at => at.Aluno)
                .Include(at => at.Turma)
                .ToList();
        }

        public List<AlunoTurma> FindByIdAluno(int id)
        {
            IQueryable<AlunoTurma> query = _context.AlunosTurmas;

            var alunoTurma = query.Include(at => at.Turma)
                             .Include(at => at.Aluno)
                             .Where(at => at.AlunoId == id)
                             .ToList();

            return alunoTurma;
        }


        public bool CreateAlunoTurma(AlunoTurma alunoTurma)
        {
            IQueryable<AlunoTurma> query = _context.AlunosTurmas;

            var cadastrado = query
                            .Include(at => at.Turma)
                            .Where(t => t.AlunoId == alunoTurma.AlunoId);

            var respsota = cadastrado.FirstOrDefault(c => c.TurmaId == alunoTurma.TurmaId);

            if (respsota == null)
            {                
                _context.Add(alunoTurma);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveAlunoTurma(int alunoId, int turmaId)
        {
            IQueryable<AlunoTurma> query = _context.AlunosTurmas;

            var alunoTurma = query
                .Where(at => at.AlunoId.Equals(alunoId))
                .Where(at => at.TurmaId.Equals(turmaId))
                .SingleOrDefault();

            if (alunoTurma == null)
                return false;

            base.Remove(alunoTurma.Id);
            _context.SaveChanges();
            return true;
            
        }
    }
}
