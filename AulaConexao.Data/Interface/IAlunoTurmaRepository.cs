using AulaConexao.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaConexao.Data.Interface
{
    public interface IAlunoTurmaRepository : IBaseRepository<AlunoTurma>
    {
        public List<AlunoTurma> GetAll();


    }
}
