using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineTurn.Data.DTOs
{
    public class UsersDto
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Location { get; set; }
    }
}
