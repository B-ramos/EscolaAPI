using AulaConexao.Domain.Models;
using System;
using System.Collections.Generic;

namespace Models.AulaConexao.Domain
{
    public class Aluno
    {
        public Aluno() { }
        public Aluno(int id, string nome, bool ativo)
        {
            Id = id;
            Nome = nome;
            Ativo = ativo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public List<AlunoTurma> AlunosTurmas { get; set; }
    }
}
