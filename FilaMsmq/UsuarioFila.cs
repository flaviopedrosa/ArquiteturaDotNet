using Dto;
using System;
using System.Messaging;

namespace FilaMsmq
{
    public class UsuarioFila : GerenciadorFilaBase<Usuario>
    {
        protected override string CaminhoFilaBase
        {
            get { return @".\private$\usuario"; }
        }

        public void AdicionarUsuarioFila(Usuario usuario)
        {
            using (MessageQueueTransaction = new MessageQueueTransaction())
            {
                try
                {

                    MessageQueueTransaction.Begin();
                    AdicionarProximoElemento(usuario);
                    MessageQueueTransaction.Commit();
                }
                catch (Exception)
                {

                    MessageQueueTransaction.Abort();
                }
            }

        }

        public override void Processar()
        {
            using (MessageQueueTransaction = new MessageQueueTransaction())
            {
                try
                {
                    MessageQueueTransaction.Begin();
                    var proximoElemento = RemoverProximoElemento();
                    Console.WriteLine("Nome:{0}\nEmail:{1}", proximoElemento.Nome, proximoElemento.Email);
                    MessageQueueTransaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    MessageQueueTransaction.Abort();
                }
            }
        }
    }
}
