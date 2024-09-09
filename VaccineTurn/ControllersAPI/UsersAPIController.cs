using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineTurn.Data;
using VaccineTurn.Data.DTOs;
using VaccineTurn.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VaccineTurn.ControllersAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAPIController : ControllerBase
    {
        private readonly AppDbContext _db;

        public UsersAPIController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult AddUser(UsersDto udto)
        {
            var newUser = new Users
            {
                Name = udto.Name,
                Age = udto.Age,
                Location = udto.Location
            };

            _db.Add(newUser);
            _db.SaveChanges();

            return RedirectToAction("TotalVaccs");
        }

        [HttpPut]
        public IActionResult UpdateUser(UsersDto udto)
        {
            var user = _db.Users.Find(udto.UserId);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                user.Name = udto.Name;
                user.Age = udto.Age;
                user.Location = udto.Location;
                _db.SaveChanges();
            }

            return RedirectToAction("TotalVaccs");
        }

    }
}
