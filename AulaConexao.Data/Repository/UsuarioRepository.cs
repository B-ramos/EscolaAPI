using AulaConexao.Data.Interface;
using AulaConexao.Domain.Models;
using SalaoCampinasTech.Data.Repository;

namespace AulaConexao.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context context) : base(context)
        {
        }
    }
}
