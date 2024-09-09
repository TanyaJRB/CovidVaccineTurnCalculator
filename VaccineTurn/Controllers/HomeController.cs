using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VaccineTurn.Data;
using VaccineTurn.Models;
using VaccineTurn.Services.Interfaces;

namespace VaccineTurn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;
        private readonly IGovernmentDataService _governmentDataService;
        private readonly IUserResultsService _userResultsService;
        private readonly ITargetService _targetService;

        public HomeController(ILogger<HomeController> logger, AppDbContext db, IGovernmentDataService governmentDataService, IUserResultsService userResultsService, ITargetService targetService)
        {
            _logger = logger;
            _db = db;
            _governmentDataService = governmentDataService;
            _userResultsService = userResultsService;
            _targetService = targetService;
        }

        public async Task<IActionResult> Index()
        {
            await _governmentDataService.GetTotalDoses(1);
            await _governmentDataService.GetTotalDoses(2);
            await _governmentDataService.GetTotalDoses(3);
            await _governmentDataService.GetDailyRate();
            await _governmentDataService.GetFirstDosesByDate();

            _targetService.CalculateTargetDailyRate();

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
    }
}
