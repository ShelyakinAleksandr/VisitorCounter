using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorCounter.SqlRequest;
using VisitorCounter.Models;
using System.Data;

namespace VisitorCounter.Infrastructure
{
    public class Visitor
    {
        public async Task<NumberVisitors> VisitorEntranceOutput(AppDb Db, int operation)
        {
            SqlQuery quevy = new SqlQuery(Db);

            int numberVisitors =  await quevy.CountVisitor(operation);

            return new NumberVisitors(numberVisitors);
        }

        public DateVisitors StatisticVisitor(AppDb Db, DateTime dateStart, DateTime? dateEnd)
        {

            DateVisitors dateVisitors = new DateVisitors();

            SqlQuery quevy = new SqlQuery(Db);

            quevy.StatisticVisitor(dateStart, dateEnd);

            return dateVisitors;
        }

       
           
    }
}
