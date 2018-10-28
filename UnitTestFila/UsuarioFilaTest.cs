using Dto;
using FilaMsmq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestFila
{
    [TestClass]
    public class UsuarioFilaTest
    {
        private readonly UsuarioFila _usuarioFila = new UsuarioFila();

        [TestMethod]
        public void AdicionarUsuarioNaFila()
        {
            _usuarioFila.AdicionarUsuarioFila(
                new Usuario()
                {
                    Nome = "Flávio Pedrosa",
                    Email = "flaviopedrosa@gmail.com"
                });
        }
        [TestMethod]
        public void ProcessarUsuarioNaFila()
        {
            _usuarioFila.Processar();
        }
    }
}
