using AulaConexao.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AulaConexao.Data.Repository
{
    public class TurmaRepository
    {
        private readonly Context context;
        public TurmaRepository()
        {
            context = new Context();
        }


        public void Post(Turma turma)
        {
            context.Turmas.Add(turma);
            context.SaveChanges();
        }

        public Turma GetById(int id)
        {
            IQueryable<Turma> query = context.Turmas;
            return query.FirstOrDefault(a => a.Id == id);
        }

        public List<Turma> GetAll()
        {
            IQueryable<Turma> query = context.Turmas;

            return query
                .Include(t => t.TurmasProfessores)
                .ThenInclude(tp => tp.Professor)
                .ToList();                           
        }

        public bool Update(int id, Turma turma)
        {
            Turma query = context.Turmas.AsNoTracking().FirstOrDefault(a => a.Id == id);
            
            if (query == null || turma.Id != id)
                return false;

            context.Turmas.Update(turma);
            context.SaveChanges();
            return true;            
        }

        public void Delete(Turma turma)
        {            
            context.Turmas.Remove(turma);
            context.SaveChanges();
        }
    }
}
