using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TaxaJuros.API.Controllers
{
    [ApiController]
    [Route("taxaJuros")]
    public class TaxaJurosController : ControllerBase
    {
        

        [HttpGet]
        
        public String Get()
        {
            var taxaJuros = "0,01";
            return taxaJuros;
        }
    }
}
