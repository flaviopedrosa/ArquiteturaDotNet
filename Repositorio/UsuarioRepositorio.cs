using Dto;

namespace Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly MysqlContext _context = new MysqlContext();

        public void Criar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
    }
}
