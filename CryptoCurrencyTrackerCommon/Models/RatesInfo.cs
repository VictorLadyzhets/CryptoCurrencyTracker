using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CryptoCurrencyTrackerCommon.Models;

namespace CryptoCurrencyTrackerCommon.Models
{
    [Table("RATES_JOURNAL")]
    public class RatesInfo
    {
        public int ID { get;  set; }
        [ForeignKey("ApiId")]
        public virtual ApiInfo API { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual ExchangeCurrencyInfo Currency { get; set; }
        public int ApiId { get; set; }
        public int CurrencyId { get; set; }
        public string Price { get; set; }
        public DateTime RateTime { get; set; }
    }
}
