using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApiCliente.Models;

namespace WebApiCliente.Controllers
{
    public class ClienteWcfController : ApiController
    {
        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]Usuario model)
        {

            var url = "http://localhost:64858/UsuarioService.svc/Criar";
            string json = JsonConvert.SerializeObject(model);
            StringContent queryString = new StringContent(json);

            var httpClient = new HttpClient();
            var response = httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));

            response.Wait();
            string resultContent = response.Result.RequestMessage.ToString();

            if (!response.IsFaulted)
            {
                return json;
            }
            else
            {
                return "Erro ao salvar usuário";
            }
        }

    }
}
