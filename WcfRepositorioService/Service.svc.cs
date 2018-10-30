using FilaMsmq;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfRepositorioService
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service1" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Service1.svc ou Service1.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class Service : IService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string Processar()
        {
            try
            {
                UsuarioFila usuarioFila = new UsuarioFila();
                var usuario = usuarioFila.Processar();
                if(string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Nome))
                {
                    return string.Format("Fila Vazia");
                }
                UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
                usuarioRepositorio.Criar(usuario);
                return string.Format("Usuário {0} processado com sucesso.", usuario.Nome);
            }
            catch (Exception e) {
                return string.Format("Falha ao processar usuário. {0}", e.Message);
            }
        }
    }
}
