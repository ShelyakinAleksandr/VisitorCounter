using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorCounter.Infrastructure;

//Южная врерь

namespace VisitorCounter.Controllers.Door
{
    [Route("[controller]")]
    [ApiController]
    public class DoorSouthController : ControllerBase
    {
        Visitor visitor = new Visitor();

        [HttpGet("SouthEntrance")]
        public async Task<NumberVisitors> SouthEntrance() => visitor.VisitorEntrance(ref Variables.visitorCounter);

        [HttpGet("SouthOutput")]
        public async Task<NumberVisitors> SouthOutput() => visitor.VisitorOutput(ref Variables.visitorCounter);
       
    }
}
