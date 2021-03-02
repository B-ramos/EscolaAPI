using AulaConexao.Domain.Base;
using Models.AulaConexao.Domain;

namespace AulaConexao.Domain.Models
{
    public class AlunoTurma : BaseEntity
    {
        
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
    }
}
