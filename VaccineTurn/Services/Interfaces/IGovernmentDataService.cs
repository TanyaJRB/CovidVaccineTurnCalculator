using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineTurn.Services.Interfaces
{
    public interface IGovernmentDataService
    {
        Task<dynamic> GetGovData(string baseUrl);
        Task GetTotalDoses(int id); 
        Task GetDailyRate();
        Task GetFirstDosesByDate();
    }
}
