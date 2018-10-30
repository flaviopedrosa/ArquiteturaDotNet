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

        public override Usuario Processar()
        {
            using (MessageQueueTransaction = new MessageQueueTransaction())
            {
                try
                {
                    MessageQueueTransaction.Begin();
                    var proximoElemento = RemoverProximoElemento();
                    MessageQueueTransaction.Commit();
                    return proximoElemento;
                }
                catch (Exception e)
                {
                    MessageQueueTransaction.Abort();
                    throw e;
                }
            }
        }
    }
}
