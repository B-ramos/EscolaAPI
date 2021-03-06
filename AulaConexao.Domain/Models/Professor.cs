﻿using AulaConexao.Domain.Base;
using AulaConexao.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel;


namespace Models.AulaConexao.Domain
{
    public class Professor : BaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Turnos Turno { get; set; }
        public List<TurmaProfessor> TurmasProfessores { get; set; }

        public enum Turnos
        {
            [Description("Manha")]
            Manha = 1,

            [Description("Tarde")]
            Tarde = 2,

            [Description("Noite")]
            Noite = 3,

            [Description("Integral")]
            Integral = 4
        }
        
    }
}
