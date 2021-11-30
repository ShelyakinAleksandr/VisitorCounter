using System;
using System.Collections.Generic;

namespace VisitorCounter.Models
{
    public class DateVisitors
    {
        public string date { get; set; }
        public List<Visitor> visitors { get; set; }
    }

    public class Visitor
    {
        public DateTime time { get; set; }
        public int visitors { get; set; }
    }
}
