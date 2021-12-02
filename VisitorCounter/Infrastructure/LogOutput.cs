using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorCounter.Infrastructure
{
    public class LogOutput
    {
        public string Informasion(string nameClass, string countVisitors)
        {
            string logInf = nameClass.Replace("Controller", "")+ "  Visitors " +countVisitors ;

            return logInf;
        }
    }
}
