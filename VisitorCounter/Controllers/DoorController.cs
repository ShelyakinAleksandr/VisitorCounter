using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorCounter.Infrastructure;

namespace VisitorCounter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoorController : ControllerBase
    {
        Visitor visitor = new Visitor();

        //Количество поситителей в торговом центре
        static int visitorCounter;

        #region "События" Входа/Выхода в ТЦ через двери

        #region Северная дверь

        [HttpGet("NorthEntrance")]
        public async Task<NumberVisitors> NorthEntrance() => visitor.VisitorEntrance(ref visitorCounter);

        [HttpGet("NorthOutput")]
        public async Task<NumberVisitors> NorthOutput() => visitor.VisitorOutput(ref visitorCounter);
        #endregion

        #region Восточная дверь

        [HttpGet("EastEntrance")]
        public async Task<NumberVisitors> EastEntrance() => visitor.VisitorEntrance(ref visitorCounter);

        [HttpGet("EastOutput")]
        public async Task<NumberVisitors> EastOutput() => visitor.VisitorOutput(ref visitorCounter);
        #endregion

        #region Южная дверь

        [HttpGet("SouthEntrance")]
        public async Task<NumberVisitors> SouthEntrance() => visitor.VisitorEntrance(ref visitorCounter);

        [HttpGet("SouthOutput")]
        public async Task<NumberVisitors> SouthOutput() => visitor.VisitorOutput(ref visitorCounter);
        #endregion

        #region Западная дверь

        [HttpGet("WestEntrance")]
        public async Task<NumberVisitors> WestEntrance() => visitor.VisitorEntrance(ref visitorCounter);

        [HttpGet("WestOutput")]
        public async Task<NumberVisitors> WestOutput() => visitor.VisitorOutput(ref visitorCounter);
        #endregion

        #endregion
    }
}
