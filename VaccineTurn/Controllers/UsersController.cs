using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineTurn.Data;
using VaccineTurn.Data.DTOs;
using VaccineTurn.Models;
using VaccineTurn.Models.ViewModels;
using VaccineTurn.Services;
using VaccineTurn.Services.Interfaces;

namespace VaccineTurn.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IGovernmentDataService _governmentDataService;
        private readonly IUserResultsService _userResultsService;
        private readonly ITargetService _targetService;

        public UsersController(AppDbContext db, IGovernmentDataService governmentDataService, IUserResultsService userResultsService, ITargetService targetService)
        {
            _db = db;
            _governmentDataService = governmentDataService;
            _userResultsService = userResultsService;
            _targetService = targetService;
        }

        //GET User
        public IActionResult UserDetails(int id)
        {
            Users relevantUser = _db.Users.Find(id);
            return View(relevantUser);
        }

        //GET Create Method
        public IActionResult CreateUser()
        {
            return View();
        }

        //POST Create Method
        [HttpPost]
        //[ValidateAntiForgeryToken] //checks if we have a token, only executes if we are logged in etc
        public IActionResult Create(Users newUser)
        {
            _db.Users.Add(newUser); //Adds object passed through from CreateUser page above to DB
            _db.SaveChanges();

            int uId = newUser.UserId;

            return RedirectToAction("UserDetails", new { id = uId }); //Rather than returning a view, redirect to the page above
        }

        [HttpGet]
        [Route("/Users/UserResults/id")]
        public IActionResult UserResults(int id)
        {
            Users relevantUser = _db.Users.Find(id);

            UsersDto udto = new UsersDto
            {
                UserId = relevantUser.UserId,
                Name = relevantUser.Name,
                Age = relevantUser.Age,
                Location = relevantUser.Location
            };

            UserResultsDto userResults = _userResultsService.GetUserResults(udto, "c");

            return View(userResults);
        }

        [HttpGet]
        [Route("/Users/UserResultsTarget/id")]
        public IActionResult UserResultsTarget(int id)
        {
            Users relevantUser = _db.Users.Find(id); 

            UsersDto udto = new UsersDto
            {
                UserId = relevantUser.UserId,
                Name = relevantUser.Name,
                Age = relevantUser.Age,
                Location = relevantUser.Location
            };

            //int targetDailyRate = _targetService.CalculateTargetDailyRate();

            UserResultsDto userResultsTarget = _userResultsService.GetUserResults(udto, "t");

            UserResultsTargetVM userResultsTargetVM = new UserResultsTargetVM()
            {
                Targets = _db.Targets.Find(1),
                UserResultsDto = userResultsTarget
            }; 
            
            return View(userResultsTargetVM);
        }


    }
}
