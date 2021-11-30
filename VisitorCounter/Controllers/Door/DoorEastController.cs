using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorCounter.Infrastructure;

//Восточна дверь

namespace VisitorCounter.Controllers.Door
{
    [Route("[controller]")]
    [ApiController]
    public class DoorEastController : ControllerBase
    {
        Visitor visitor = new Visitor();

        [HttpGet("EastEntrance")]
        public async Task<NumberVisitors> EastEntrance() => visitor.VisitorEntrance(ref Variables.visitorCounter);

        [HttpGet("EastOutput")]
        public async Task<NumberVisitors> EastOutput() => visitor.VisitorOutput(ref Variables.visitorCounter);
    }
}
