using System.Collections.Generic;
using System.Threading.Tasks;
using Asp.NetCoreConsumingApi.Models;
using Asp.NetCoreConsumingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreConsumingApi.Controllers
{
    public class HolidayController: Controller
    {
        private readonly IHolidaysApiService _iholidaysApiServices;

        public HolidayController(IHolidaysApiService holidaysApiService){

            _iholidaysApiServices = holidaysApiService;
        }

        public async Task<IActionResult> Index(string countryCode, int year){

            List<HolidayModel> holiday = new List<HolidayModel>();
            holiday = await _iholidaysApiServices.GetHolidays(countryCode, year);

            return View(holiday);
        }
    }
}