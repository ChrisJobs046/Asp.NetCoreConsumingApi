using System.Collections.Generic;
using System.Threading.Tasks;
using Asp.NetCoreConsumingApi.Models;

namespace Asp.NetCoreConsumingApi.Services
{
    public interface IHolidaysApiService
    {
        Task<List<HolidayModel>> GetHolidays(string countryCode, int year);
    }
}