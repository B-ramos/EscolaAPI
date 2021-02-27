using Models.AulaConexao.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaConexao.Domain.Models
{
    public class Turma
    {
        public Turma() { }

        public Turma(int id, string nome, string descricao, Professor professor)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;            
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<TurmaProfessor> TurmasProfessores { get; set; }
        public List<AlunoTurma> AlunosTurmas { get; set; }
    }
}
