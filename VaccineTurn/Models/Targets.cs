using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineTurn.Models
{
    public class Targets
    {
        [Key]
        public int TargetsId { get; set; }

        [DisplayName("Target Date for providing all adults with a First Dose:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TargetDate { get; set; }

        [DisplayName("Target number of people to vaccinate:")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public int TargetFirstDoses { get; set; }

        [DisplayName("To achieve this, the Daily Rate (from today onwards) would have to be:")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public int TargetDailyRate { get; set; }

        [DisplayName("The Weekly Rate would have to be:")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public int TargetWeeklyRate { get; set; }

    }
}
