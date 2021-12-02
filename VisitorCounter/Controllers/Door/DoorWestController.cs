using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<DoorWestController> logger;

        LogOutput logOutput = new LogOutput();
        Visitor visitor = new Visitor();
        AppDb Db { get; }

        public DoorWestController(AppDb db, ILogger<DoorWestController> logger)
        {
            this.logger = logger;
            Db = db;
        }

        [HttpGet("WestEntrance")]
        public async Task<NumberVisitors> WestEntrance()
        {
            NumberVisitors numberVisitors = await visitor.VisitorEntranceOutput(Db, 0);

            logger.LogInformation(logOutput.Informasion(GetType().Name, numberVisitors.Visitors));

            return numberVisitors;
        }

        [HttpGet("WestOutput")]
        public async Task<NumberVisitors> WestOutput()
        {
            NumberVisitors numberVisitors = await visitor.VisitorEntranceOutput(Db, 1);

            logger.LogInformation(logOutput.Informasion(GetType().Name, numberVisitors.Visitors));

            return numberVisitors;
        }
    }
}
