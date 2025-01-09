using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubCore.Models
{
        public class Alarm
        {
            public DateTime GeneratedAt { get; set; }
            public string Message { get; set; }
            public int RiskLevel { get; set; }
        }
}
