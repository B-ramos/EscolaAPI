using AulaConexao.Domain.Base;
using AulaConexao.Domain.Models;
using System.Collections.Generic;

namespace Models.AulaConexao.Domain
{
    public class Aluno : BaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public List<AlunoTurma> AlunosTurmas { get; set; }
    }
}
