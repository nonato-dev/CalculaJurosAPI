using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculaJuros.API.Controllers
{
    [ApiController]
    [Route("showmethecode")]
    public class ShowmethecodeController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public string Get()
        {
            return "git Url";
        }
    }
}
