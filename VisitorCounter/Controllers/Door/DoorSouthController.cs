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
        AppDb Db { get; }

        public DoorSouthController(AppDb db)
        {
            Db = db;
        }

        [HttpGet("SouthEntrance")]
        public async Task<NumberVisitors> SouthEntrance() => visitor.VisitorEntranceOutput(Db, 0);

        [HttpGet("SouthOutput")]
        public async Task<NumberVisitors> SouthOutput() => visitor.VisitorEntranceOutput(Db, 1);

    }
}
