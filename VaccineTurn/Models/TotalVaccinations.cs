using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineTurn.Models
{
    public class TotalVaccinations
    {
        [Key]
        public int TotalVaccinationsId { get; set; }

        [DisplayName("Date Updated")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CurrentDate { get; set; }

        [DisplayName("Vaccine Type")]
        public string VaccType { get; set; }

        [DisplayName("Doses Administered")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public int TotalDoses { get; set; }

    }
}
