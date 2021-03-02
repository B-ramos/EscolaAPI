using AulaConexao.Data.Interface;
using AulaConexao.Domain.Models;
using Microsoft.EntityFrameworkCore;
using SalaoCampinasTech.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AulaConexao.Data.Repository
{
    public class TurmaProfessorRepository : BaseRepository<TurmaProfessor>, ITurmaProfessorRepository
    {
        public TurmaProfessorRepository(Context context) : base(context) { }

        public List<TurmaProfessor> GetAll()
        {
            IQueryable<TurmaProfessor> query = _context.TurmasProfessores;


            return query
                .Include(tp => tp.Turma)
                .Include(tp => tp.Professor)
                .ToList();
        }

        //public TurmaProfessor GetById(int id)
        //{
        //    IQueryable<TurmaProfessor> query = context.TurmasProfessores;

        //    var turma = query.Include(tp => tp.Turma)
        //                     .Include(tp => tp.Professor)
        //                     .ToList();

        //    return turma.FirstOrDefault(a => a.Id == id);
        //}



    }
}
