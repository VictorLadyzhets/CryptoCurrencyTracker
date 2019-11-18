using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoCurrencyTrackerCommon.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CryptoCurrencyTrackerCommon.Models.DataLayer
{
    public class CryptoCurrencyTrackerContext : DbContext
    {
        public DbSet<RatesInfo> Rates { get; set; }
        public DbSet<ApiInfo> API { get; set; }
        public DbSet<ExchangeCurrencyInfo> Currency { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-76BTKSC\MSSQLSERVER01;Database=CryptoCurrencyTrackerDB;Trusted_Connection=true;");
            }
        }
    }
}
