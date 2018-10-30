using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSCoreCliente
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CLienteWcfController : Controller
    {
       

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]Usuario model)
        {
   
            var url = "http://localhost:64858/UsuarioService.svc/Criar";
            string json = JsonConvert.SerializeObject(model);
            StringContent queryString = new StringContent(json);

            var httpClient = new HttpClient();
            var response =  httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
           
            response.Wait();
            string resultContent = response.Result.RequestMessage.ToString();

            if (response.IsCompletedSuccessfully)
            {
                return json;
            }
            else {
                return "Erro ao salvar usuário";
            }
        }

        
    }
}
