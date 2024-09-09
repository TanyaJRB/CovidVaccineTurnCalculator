using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineTurn.Models
{
    public class DailyRate
    {
        [Key]
        public int DailyRateId { get; set; }

        [DisplayName("Date Updated")]
        public DateTime CurrentDate { get; set; }

        [DisplayName("Rate of Vaccination (100,000s)")]
        public int CurrentRate { get; set; }

    }
}
