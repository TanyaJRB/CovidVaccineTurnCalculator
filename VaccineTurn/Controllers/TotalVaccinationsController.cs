using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineTurn.Data;
using VaccineTurn.Models;
using VaccineTurn.Models.ViewModels;
using VaccineTurn.Services;
using VaccineTurn.Services.Interfaces;

namespace VaccineTurn.Controllers
{
    public class TotalVaccinationsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IGovernmentDataService _governmentDataService;
        private readonly IUserResultsService _userResultsService;
        private readonly ITargetService _targetService;

        public TotalVaccinationsController(AppDbContext db, IGovernmentDataService governmentDataService, IUserResultsService userResultsService, ITargetService targetService)
        {
            _db = db;
            _governmentDataService = governmentDataService;
            _userResultsService = userResultsService;
            _targetService = targetService;
        }

        public IActionResult Dashboard()
        {

            DashboardVM dashboardVM = new DashboardVM()
            {
                TotalVaccinations = _db.TotalVaccinations,
                Targets = _db.Targets.Find(1),
                DailyRate = _db.DailyRate.OrderByDescending(dr => dr.CurrentDate).Take(5),
                PopulationGroups = _db.PopulationGroups
            };

            return View(dashboardVM);
        }



    }
}
