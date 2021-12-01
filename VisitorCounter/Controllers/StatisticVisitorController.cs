using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorCounter.Infrastructure;
using VisitorCounter.Models;
using System.Data;
using VisitorCounter.SqlRequest;

namespace VisitorCounter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatisticVisitorController : ControllerBase
    {
        Visitor visitor = new Visitor();
        AppDb Db { get; }

        public StatisticVisitorController(AppDb db)
        {
            Db = db;
        }

        [HttpPost]
        public async Task<IActionResult> StatisticVisitor(RequestDate requestDate)
        {
            DateVisitors dateVisitors = new DateVisitors();
            SqlQuery sqlQuery = new SqlQuery(Db);
            DataTable dataTable = sqlQuery.StatisticVisitor(requestDate.DateStart, requestDate.DateEnd);
            
            //получаем список дат
            List<object> listDate = dataTable
                 .AsEnumerable()
                 .Select(row => row["DateTimeVisitor"])
                 .Distinct()
                 .ToList();

            for (int i = 0; i < listDate.Count; i++)
            {
                dateVisitors.date = listDate[i].ToString();

                var d = dataTable.Select("DateTimeVisitor ="+ listDate[i]).ToList();
            }

            return new OkObjectResult(dateVisitors);
        }

    }
}
