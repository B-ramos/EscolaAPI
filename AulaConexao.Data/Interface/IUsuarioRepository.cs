using AulaConexao.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaConexao.Data.Interface
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        public Usuario SelecionarPorNomeESenha(string nome, string senha);
    }
}
