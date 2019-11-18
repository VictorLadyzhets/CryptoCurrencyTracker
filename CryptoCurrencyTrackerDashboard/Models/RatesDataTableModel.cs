using CryptoCurrencyTrackerCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCurrencyTrackerDashboard.Models
{
    public class RatesDataTableModel : DataTableResponse
    {
        public List<RatesInfo> data { get; set; }
    }
}
