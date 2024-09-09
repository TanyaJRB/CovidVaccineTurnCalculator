using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineTurn.Data;
using VaccineTurn.Data.DTOs;
using VaccineTurn.Models;
using VaccineTurn.Services;
using VaccineTurn.Services.Interfaces;

namespace VaccineTurn.Controllers
{
    public class TargetsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IGovernmentDataService _governmentDataService;
        private readonly IUserResultsService _userResultsService;
        private readonly ITargetService _targetService;

        public TargetsController(AppDbContext db, IGovernmentDataService governmentDataService, IUserResultsService userResultsService, ITargetService targetService)
        {
            _db = db;
            _governmentDataService = governmentDataService;
            _userResultsService = userResultsService;
            _targetService = targetService;
        }

        public async Task<IActionResult> Targets()
        {
            await _governmentDataService.GetTotalDoses(1);
            await _governmentDataService.GetTotalDoses(2);
            await _governmentDataService.GetTotalDoses(3);
            await _governmentDataService.GetDailyRate();
            await _governmentDataService.GetFirstDosesByDate();

            int targetDR = _targetService.CalculateTargetDailyRate();

            IEnumerable<Targets> targetStats = _db.Targets;
            return View(targetStats);
        }



    }
}
