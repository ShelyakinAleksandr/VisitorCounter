using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<DoorNorthController> logger;

        LogOutput logOutput = new LogOutput();
        Visitor visitor = new Visitor();
        AppDb Db { get; }

        public DoorNorthController(AppDb db, ILogger<DoorNorthController> logger)
        {
            this.logger = logger;
            Db = db;
        }

        [HttpGet("NorthEntrance")]
        public async Task<NumberVisitors> NorthEntrance()
        {
            NumberVisitors numberVisitors = await visitor.VisitorEntranceOutput(Db, 0);

            logger.LogInformation(logOutput.Informasion(GetType().Name, numberVisitors.Visitors));

            return numberVisitors;
        }

        [HttpGet("NorthOutput")]
        public async Task<NumberVisitors> NorthOutput() 
        {
            NumberVisitors numberVisitors = await visitor.VisitorEntranceOutput(Db, 1);

            logger.LogInformation(logOutput.Informasion(GetType().Name, numberVisitors.Visitors));

            return numberVisitors;
        } 

    }
}
