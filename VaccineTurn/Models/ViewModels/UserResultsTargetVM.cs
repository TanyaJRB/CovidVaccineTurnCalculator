using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VaccineTurn.Data.DTOs;

namespace VaccineTurn.Models.ViewModels
{
    [Keyless]
    public class UserResultsTargetVM
    {
        public Targets Targets { get; set; }
        public UserResultsDto UserResultsDto { get; set; }
    }
}
