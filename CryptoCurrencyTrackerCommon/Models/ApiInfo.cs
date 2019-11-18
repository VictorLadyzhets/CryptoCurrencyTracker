using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CryptoCurrencyTrackerCommon.Models
{
    [Table("EXCHANGE_API")]
    public class ApiInfo
    {
        public int ID { get;  set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
