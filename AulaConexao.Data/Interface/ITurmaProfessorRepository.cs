using AulaConexao.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaConexao.Data.Interface
{
    public interface ITurmaProfessorRepository : IBaseRepository<TurmaProfessor>
    {
        public List<TurmaProfessor> GetAll();
        public List<TurmaProfessor> GetByIdProfessor(int id);
    }
}
