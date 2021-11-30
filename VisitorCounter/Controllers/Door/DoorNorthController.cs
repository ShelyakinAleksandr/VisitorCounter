using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorCounter.Infrastructure;

//Северная Дверь

namespace VisitorCounter.Controllers.Door
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorNorthController : ControllerBase
    {
        Visitor visitor = new Visitor();

        [HttpGet("NorthEntrance")]
        public async Task<NumberVisitors> NorthEntrance() => visitor.VisitorEntrance(ref Variables.visitorCounter);

        [HttpGet("NorthOutput")]
        public async Task<NumberVisitors> NorthOutput() => visitor.VisitorOutput(ref Variables.visitorCounter);

    }
}
