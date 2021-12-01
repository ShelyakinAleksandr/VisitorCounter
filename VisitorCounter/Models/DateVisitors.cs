using System;
using System.Collections.Generic;

namespace VisitorCounter.Models
{
    public class DateVisitors
    {
        public string date { get; set; }
        public List<CountVisitor> visitors { get; set; }
    }

    public class CountVisitor
    {
        public DateTime time { get; set; }
        public int visitors { get; set; }
    }
}
