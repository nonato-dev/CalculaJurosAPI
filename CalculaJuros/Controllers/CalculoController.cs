using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System;

namespace CalculaJuros.API.Controllers
{
    [ApiController]
    [Route("calculaJuros")]
    public class CalculoController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public string Get(decimal valorInicial, int meses)
        {
            var taxaJuros = GetTaxaJuros();
            
            var valor = valorInicial * (decimal)System.Math.Pow((double)(1 + taxaJuros), meses);
            var valorFinal = Math.Round(valor, 2);

            return valorFinal.ToString();
        }

        private decimal GetTaxaJuros()
        {
            var client = new HttpClient();
            try
            {
                var strUrlEnderecoAPI = "https://localhost:44383/taxaJuros";
                var request = new HttpRequestMessage(HttpMethod.Get, strUrlEnderecoAPI);
                request.Headers.Add("Accept", "application/json");
                
                var response = client.SendAsync(request).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                return Convert.ToDecimal(JsonConvert.DeserializeObject<object>(result));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}