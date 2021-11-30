using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorCounter.Infrastructure
{
    public class Visitor
    {
        public NumberVisitors VisitorEntrance(ref int visitorCounter) => new NumberVisitors(++visitorCounter);

        public NumberVisitors VisitorOutput(ref int visitorCounter)
        {
            if (visitorCounter > 0)
                return new NumberVisitors(--visitorCounter);
            else
                return new NumberVisitors(visitorCounter);
        }
           
    }
}
