using AulaConexao.Domain.Base;

namespace AulaConexao.Domain.Models
{
    public class Usuario :BaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
    }
}
