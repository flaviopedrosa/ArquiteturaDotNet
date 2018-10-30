using Dto;
using FilaMsmq;
using System;

namespace WcfRestService
{

    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioFila _usuarioFila = new UsuarioFila();
        public string Criar(string nome, string email)
        {
            try
            {
                _usuarioFila.AdicionarUsuarioFila(
                    new Usuario()
                    {
                        Nome = nome,
                        Email = email
                    });

                return "Nome do usuario criado:  " + nome + "de email: " + email;
            }
            catch (Exception e) {
                return e.Message;
            }
        }
    }
}
