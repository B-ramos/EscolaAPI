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

        //public AlunoTurma GetById(int id)
        //{
        //    IQueryable<AlunoTurma> query = context.AlunosTurmas;

        //    var aluno = query.Include(at => at.Turma)
        //                     .Include(at => at.Aluno)
        //                     .ToList();

        //    return aluno.FirstOrDefault(a => a.Id == id);
        //}

        //public List<AlunoTurma> GetAll()
        //{
        //    IQueryable<AlunoTurma> query = context.AlunosTurmas;

        //    return query
        //        .Include(at => at.Aluno)
        //        .Include(at => at.Turma)
        //        .ToList();

        //}

    }
}
