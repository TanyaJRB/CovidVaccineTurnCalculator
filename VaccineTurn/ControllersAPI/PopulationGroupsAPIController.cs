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
    public class PopulationGroupsAPIController : ControllerBase
    {
        private readonly AppDbContext _db;

        public PopulationGroupsAPIController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/<PopulationGroupsAPIController>
        [HttpGet]
        public IEnumerable<PopulationGroups> GetAllPopGroups()
        {
            return _db.PopulationGroups;
        }

        // GET By ID api/<PopulationGroupsAPIController>/5
        [HttpGet("{id}")]
        public IEnumerable<PopulationGroups> GetPopGroupById(int id)
        {
            IEnumerable<PopulationGroups> pg = _db.PopulationGroups.Where(p => p.PopulationGroupsId == id).ToList();
            return pg;
        }

        // GET api/<PopulationGroupsAPIController>/5
        [HttpGet("agegroup/{age}")]
        public IEnumerable<PopulationGroups> GetByAge(int age)
        {
            IEnumerable<PopulationGroups> pg = _db.PopulationGroups.Where(p => p.AgeGroupMin <= age & age <= p.AgeGroupMax).ToList();
            return pg;
        }

        [HttpPost]
        public IActionResult AddPopGroup(PopulationGroups popGroup)
        {
            var newPopGroup = new PopulationGroups
            {
                AgeGroupMin = popGroup.AgeGroupMin,
                AgeGroupMax = popGroup.AgeGroupMax,
                NumberPeople = popGroup.NumberPeople,
                CurrentPopGroup = popGroup.CurrentPopGroup
            };

            _db.Add(newPopGroup);
            _db.SaveChanges();

            return Ok();
        }

    }
}
