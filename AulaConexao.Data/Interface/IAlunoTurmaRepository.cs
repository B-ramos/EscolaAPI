using AulaConexao.Domain.Models;
using Models.AulaConexao.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaConexao.Data.Interface
{
    public interface IAlunoTurmaRepository : IBaseRepository<AlunoTurma>
    {
        public List<AlunoTurma> FindByIdAluno(int id);

        public bool CreateAlunoTurma(AlunoTurma alunoTurma);

        public bool RemoveAlunoTurma(int alunoId, int turmaId);


    }
}
