using AulaConexao.Data.Interface;
using AulaConexao.Domain.Models;
using Microsoft.EntityFrameworkCore;
using SalaoCampinasTech.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AulaConexao.Data.Repository
{
    public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
    {
        public TurmaRepository(Context context) : base(context) { }
        //public List<Turma> GetAll()
        //{
        //    IQueryable<Turma> query = context.Turmas;

        //    return query
        //        .Include(t => t.TurmasProfessores)
        //        .ThenInclude(tp => tp.Professor)
        //        .ToList();                           
        //}

    }
}
