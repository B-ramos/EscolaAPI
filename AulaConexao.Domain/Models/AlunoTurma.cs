using Models.AulaConexao.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaConexao.Domain.Models
{
    public class AlunoTurma
    {
        public AlunoTurma() { }
        public AlunoTurma(int id, int alunoId, int turmaId)
        {
            Id = id;
            AlunpId = alunoId;
            TurmaId = turmaId;
        }

        public int Id { get; set; }
        public int AlunpId { get; set; }
        public Aluno Aluno { get; set; }
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
    }
}
