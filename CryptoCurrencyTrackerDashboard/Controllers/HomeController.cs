using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CryptoCurrencyTrackerDashboard.Models;
using CryptoCurrencyTrackerCommon.Models.DataLayer;
using CryptoCurrencyTrackerCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoCurrencyTrackerDashboard.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult LoadData(DataTableRequest request)
        {
            try
            {
                var context = new CryptoCurrencyTrackerContext();
                int pageSize = request.length;
                int skip = request.start;
                int recordsTotal = 0;

                var ratesData = context.Rates.Include(x => x.API).Include(m => m.Currency).ToList<RatesInfo>();

                recordsTotal = ratesData.Count();
                var data = ratesData.Skip(skip).Take(pageSize).ToList();
                return Json(new RatesDataTableModel{ draw = request.draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
