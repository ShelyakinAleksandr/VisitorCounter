using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        AppDb Db { get; }

        public DoorEastController(AppDb db)
        {
            Db = db;
        }

        [HttpGet("EastEntrance")]
        public async Task<NumberVisitors> EastEntrance() => visitor.VisitorEntranceOutput(Db,0);

        [HttpGet("EastOutput")]
        public async Task<NumberVisitors> EastOutput() => visitor.VisitorEntranceOutput(Db,1);
    }
}
