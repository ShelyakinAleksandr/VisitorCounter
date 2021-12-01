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
            List<DateVisitors> listVisitors = new List<DateVisitors>();
           
            SqlQuery sqlQuery = new SqlQuery(Db);
            DataTable dataTable = sqlQuery.StatisticVisitor(requestDate.DateStart, requestDate.DateEnd);

            //получаем список дат
            List<object> listDate = dataTable
                 .AsEnumerable()
                 .Select(row => row["Date"])
                 .Distinct()
                 .ToList();


            for (int i = 0; i < listDate.Count; i++)
            {
                DateVisitors dateVisitors = new DateVisitors();
                dateVisitors.date = listDate[i].ToString();

                List<DataRow> list = dataTable.Select("Date ='" + listDate[i].ToString()+"'" ).ToList();

                Dictionary<string, int> timeVisitors = new Dictionary<string, int>();

                for (int j = 0; j < list.Count; j++)
                {
                    timeVisitors.Add( 
                         Convert.ToDateTime(list[j]["Time"]).ToString("H:mm"),
                         Convert.ToInt32(list[j]["VisitorCount"])
                    );
                    
                }
                dateVisitors.visitors = timeVisitors;
                listVisitors.Add(dateVisitors);
            }

            return new OkObjectResult(listVisitors);
        }

    }
}
