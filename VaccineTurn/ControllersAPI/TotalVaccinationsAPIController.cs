using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineTurn.Data;
using VaccineTurn.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VaccineTurn.ControllersAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalVaccinationsAPIController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TotalVaccinationsAPIController(AppDbContext db)
        {
            _db = db;
        }
       
        [HttpPost]
        public IActionResult AddVaccStat(TotalVaccinations vaccStat)
        {
            var newVaccStat = new TotalVaccinations
            {
                VaccType = vaccStat.VaccType,
                TotalDoses = vaccStat.TotalDoses
            };

            _db.Add(newVaccStat);
            _db.SaveChanges();

            return RedirectToAction("TotalVaccs");
        }

        [HttpPut]
        public IActionResult UpdateVaccStat(int id, int newValue)
        {
            var statToUpdate = _db.TotalVaccinations.Find(id);
            if (statToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                statToUpdate.TotalDoses = newValue;
            }

            _db.SaveChanges();

            return Ok();
        }

    }
}
