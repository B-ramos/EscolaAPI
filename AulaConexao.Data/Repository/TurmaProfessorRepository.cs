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

        public List<TurmaProfessor> GetByIdProfessor(int id)
        {
            IQueryable<TurmaProfessor> query = _context.TurmasProfessores;

            var turmaProfessor = query.Include(tp => tp.Turma)
                             .Include(tp => tp.Professor)
                             .Where(tp => tp.ProfessorId == id)
                             .ToList();

            return turmaProfessor;
        }



    }
}
