using AulaConexao.Data.Interface;
using AulaConexao.Domain.Models;
using Microsoft.EntityFrameworkCore;
using SalaoCampinasTech.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AulaConexao.Data.Repository
{
    public class AlunoTurmaRepository : BaseRepository<AlunoTurma>, IAlunoTurmaRepository
    {
        public AlunoTurmaRepository(Context context) : base(context) { }

        public List<AlunoTurma> GetAll()
        {
            IQueryable<AlunoTurma> query = _context.AlunosTurmas;

            return query
                .Include(at => at.Aluno)
                .Include(at => at.Turma)
                .ToList();

        }

        public List<AlunoTurma> GetByIdAluno(int id)
        {
            IQueryable<AlunoTurma> query = _context.AlunosTurmas;

            var alunoTurma = query.Include(at => at.Turma)
                             .Include(at => at.Aluno)
                             .Where(at => at.AlunoId == id)
                             .ToList();

            return alunoTurma;
        }

        

    }
}
