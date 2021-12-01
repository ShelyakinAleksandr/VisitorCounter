using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorCounter.Infrastructure;

//Западная дверь

namespace VisitorCounter.Controllers.Door
{
    [Route("[controller]")]
    [ApiController]
    public class DoorWestController : ControllerBase
    {
        Visitor visitor = new Visitor();
        AppDb Db { get; }

        public DoorWestController(AppDb db)
        {
            Db = db;
        }

        [HttpGet("WestEntrance")]
        public async Task<NumberVisitors> WestEntrance() => visitor.VisitorEntranceOutput(Db, 0);

        [HttpGet("WestOutput")]
        public async Task<NumberVisitors> WestOutput() => visitor.VisitorEntranceOutput(Db, 1);
    }
}
