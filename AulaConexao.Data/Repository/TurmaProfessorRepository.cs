using AulaConexao.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AulaConexao.Data.Repository
{
    public class TurmaProfessorRepository
    {
        private readonly Context context;
        public TurmaProfessorRepository()
        {
            context = new Context();
        }


        public void Post(TurmaProfessor turmaProfessor)
        {
            context.TurmasProfessores.Add(turmaProfessor);
            context.SaveChanges();
        }

        public TurmaProfessor GetById(int id)
        {
            IQueryable<TurmaProfessor> query = context.TurmasProfessores;

            var turma = query.Include(tp => tp.Turma)
                             .Include(tp => tp.Professor)
                             .ToList();

            return turma.FirstOrDefault(a => a.Id == id);
        }

        public List<TurmaProfessor> GetAll()
        {
            IQueryable<TurmaProfessor> query = context.TurmasProfessores;

            
            return query
                .Include(tp => tp.Turma) 
                .Include(tp => tp.Professor)
                .ToList();
                          
        }

        public bool Update(int id, TurmaProfessor turmaProfessor)
        {
            TurmaProfessor query = context.TurmasProfessores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            
            if (query == null || turmaProfessor.Id != id)
                return false;

            context.TurmasProfessores.Update(turmaProfessor);
            context.SaveChanges();
            return true;            
        }

        public void Delete(TurmaProfessor turmaProfessor)
        {            
            context.TurmasProfessores.Remove(turmaProfessor);
            context.SaveChanges();
        }
    }
}
