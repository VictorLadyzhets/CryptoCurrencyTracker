using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CryptoCurrencyTrackerCommon.Models
{
    [Table("EXCHANGE_CURRENCY")]
    public class ExchangeCurrencyInfo
    {
        public int ID { get;  set; }
        public string Name { get; set; }

    }
}
