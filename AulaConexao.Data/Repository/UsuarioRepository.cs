using AulaConexao.Data.Interface;
using AulaConexao.Domain.Models;
using SalaoCampinasTech.Data.Repository;
using System.Linq;

namespace AulaConexao.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context context) : base(context)
        {

        }

        public Usuario SelecionarPorNomeESenha(string nome, string senha)
        {
            return _context.Set<Usuario>()
                     .FirstOrDefault(u => u.Nome == nome && u.Senha == senha);
        }
    }
}
