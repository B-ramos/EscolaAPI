using AulaConexao.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Models.AulaConexao.Domain;
using SalaoCampinasTech.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AulaConexao.Data.Repository
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(Context context) : base(context) { }

        
    }
}
