using Models.AulaConexao.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaConexao.Domain.Models
{
    public class TurmaProfessor
    {
        public TurmaProfessor() { }
        
        public TurmaProfessor(int id, int turmaId, int professorId)
        {
            Id = id;
            TurmaId = turmaId;            
            ProfessorId = professorId;            
        }
        public int Id { get; set; }
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}
