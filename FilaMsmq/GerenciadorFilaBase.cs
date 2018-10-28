using System.Messaging;


namespace FilaMsmq
{
    public abstract class GerenciadorFilaBase<T>
    {
        protected abstract string CaminhoFilaBase { get; }
        protected MessageQueueTransaction MessageQueueTransaction { get; set; }
        private MessageQueue MsmQBase()
        {
            var msmq = new MessageQueue(CaminhoFilaBase);

            if (MessageQueue.Exists(CaminhoFilaBase))
            {
                msmq.Formatter = new BinaryMessageFormatter();
                return msmq;
            }

            msmq = MessageQueue.Create(CaminhoFilaBase, true);
            return msmq;
        }
        protected void AdicionarProximoElemento(T objeto)
        {
            MsmQBase().Send(objeto, MessageQueueTransaction);
        }
        protected T RemoverProximoElemento()
        {
            var proximoElemento = MsmQBase().Receive(MessageQueueTransaction).Body;

            return (T)proximoElemento;

        }

        public abstract void Processar();
    }
}
