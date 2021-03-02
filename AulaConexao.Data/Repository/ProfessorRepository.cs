using AulaConexao.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Models.AulaConexao.Domain;
using SalaoCampinasTech.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulaConexao.Data.Repository
{
    public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(Context context) : base(context) { }
        
    }
}
