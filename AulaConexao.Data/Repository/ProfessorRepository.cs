using Microsoft.EntityFrameworkCore;
using Models.AulaConexao.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulaConexao.Data.Repository
{
    public class ProfessorRepository
    {
        private readonly Context context;
        public ProfessorRepository()
        {
            context = new Context();
        }

        public void Post(Professor professor)
        {
            context.Professores.Add(professor);
            context.SaveChanges();
        }

        public Professor GetById(int id)
        {
            IQueryable<Professor> query = context.Professores;
            return query.FirstOrDefault(p => p.Id == id);
        }

        public List<Professor> GetAll()
        {
            IQueryable<Professor> query = context.Professores;
            return query.ToList();
        }

        public bool Update(int id, Professor professor)
        {
            Professor query = context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if (query == null || professor.Id != id)
                return false;

            context.Professores.Update(professor);
            context.SaveChanges();
            return true;
        }

        public void Delete(Professor professor)
        {
            context.Professores.Remove(professor);
            context.SaveChanges();
        }
    }
}
