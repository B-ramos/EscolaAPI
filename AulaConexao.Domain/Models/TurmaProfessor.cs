using AulaConexao.Domain.Base;
using Models.AulaConexao.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaConexao.Domain.Models
{
    public class TurmaProfessor : BaseEntity
    {
        public int Id { get; set; }
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}
