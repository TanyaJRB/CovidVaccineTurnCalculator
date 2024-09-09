using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineTurn.Models
{
    public class FirstDosesByDate
    {
        [Key]
        public int FirstDosesByDateId { get; set; }

        [DisplayName("Date Updated")]
        public DateTime CurrentDate { get; set; }

        [DisplayName("Doses Administered")]
        public int TotalFirstDoses { get; set; }
    }
}
