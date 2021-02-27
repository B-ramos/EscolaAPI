using Microsoft.EntityFrameworkCore;
using Models.AulaConexao.Domain;
using System.Collections.Generic;
using System.Linq;

namespace AulaConexao.Data.Repository
{
    public class AlunoRepository
    {
        private readonly Context context;
        public AlunoRepository()
        {
            context = new Context();
        }


        public void Post(Aluno aluno)
        {
            context.Alunos.Add(aluno);
            context.SaveChanges();
        }

        public Aluno GetById(int id)
        {
            IQueryable<Aluno> query = context.Alunos;
            return query.FirstOrDefault(a => a.Id == id);
        }

        public List<Aluno> GetAll()
        {
            IQueryable<Aluno> query = context.Alunos;
            return query.ToList();
                //.Include(a => a.AlunosCursos)
                //.ThenInclude(ac => ac.Curso)
                //.ThenInclude(c => c.CursosDisciplinas)
                //.ThenInclude(cd => cd.Disciplina)
                //.ThenInclude(d => d.Professor)
                //.ToList();           
        }

        public bool Update(int id, Aluno aluno)
        {
            Aluno query = context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            
            if (query == null || aluno.Id != id)
                return false;

            context.Alunos.Update(aluno);
            context.SaveChanges();
            return true;            
        }

        public void Delete(Aluno aluno)
        {            
            context.Alunos.Remove(aluno);
            context.SaveChanges();
        }
    }
}
