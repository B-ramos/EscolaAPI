using AulaConexao.Domain.Base;
using Models.AulaConexao.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaConexao.Domain.Models
{
    public class Turma : BaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<TurmaProfessor> TurmasProfessores { get; set; }
        public List<AlunoTurma> AlunosTurmas { get; set; }
    }
}
