using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfRestService
{

    [ServiceContract]
    public interface IUsuarioService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Criar", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string Criar(string nome, string email);

    }
}
