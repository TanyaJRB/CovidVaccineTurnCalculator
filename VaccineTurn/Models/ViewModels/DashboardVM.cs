using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineTurn.Models.ViewModels
{
    [Keyless]
    public class DashboardVM
    {
        public IEnumerable<TotalVaccinations> TotalVaccinations { get; set; }
        public Targets Targets { get; set; }

        public IQueryable<DailyRate> DailyRate { get; set; }

        public IEnumerable<PopulationGroups> PopulationGroups { get; set; }

    }
}
