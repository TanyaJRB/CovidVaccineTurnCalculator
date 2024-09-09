using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineTurn.Data.DTOs
{
    public class UserResultsDto
    {
        [Key]
        public int UserId { get; set; }
        public int Age { get; set; }

        [DisplayName("Your Population Age Group")]
        public string YourPopulationGroup { get; set; }

        [DisplayName("Current Population Age Group Being Vaccinated")]
        public string CurrentPopulationGroup { get; set; }

        [DisplayName("Number of People Ahead of You")]
        public string PeopleAhead { get; set; }

        [DisplayName("Current Daily Rate of Vaccinations")]
        public string CurrentDailyRate { get; set; }

        [DisplayName("First Dose Vaccinations Administered to Date")]
        public string FirstDosesToDate { get; set; }

        [DisplayName("Earliest Date for Vaccination (based on Current Daily Rate)")]
        public string EarliestVaccineDate { get; set; }

        
    }
}
