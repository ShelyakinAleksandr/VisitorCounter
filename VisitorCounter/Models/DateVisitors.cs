using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VisitorCounter.Models
{
    public class DateVisitors
    {
        public string date { get; set; }
        public Dictionary<string,int> visitors { get; set; }

    }

    
}
