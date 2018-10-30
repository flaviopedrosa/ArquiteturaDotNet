using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio;

namespace UnitTestFila
{
    [TestClass]
    public class UsuarioRepositorioTest
    {
        [TestMethod]
        public void CriarUsuarioInDb()
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            repositorio.Criar(new Dto.Usuario { Nome = "Flávio", Email = "flaviopedrosa@gmail.com" });
        }
    }
}
