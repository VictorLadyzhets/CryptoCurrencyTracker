using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCurrencyTrackerDashboard.Models
{
    public class DataTableRequest
    {
        public int draw { get; set; }
        public int length { get; set; }
        public int start { get; set; }
    }
}
