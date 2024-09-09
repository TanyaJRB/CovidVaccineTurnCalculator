using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineTurn.Models
{
    public class PopulationGroups
    {
        [Key]
        public int PopulationGroupsId { get; set; }

        [DisplayName("From Age")]
        public int AgeGroupMin { get; set; }

        [DisplayName("To Age")]
        public int AgeGroupMax { get; set; }

        [DisplayName("Number of People")]
        public int NumberPeople { get; set; }

        public bool CurrentPopGroup { get; set; }

        public DateTime DateOfAnnouncement { get; set; }
    }
}
