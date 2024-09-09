using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineTurn.Models;
using VaccineTurn.Data.DTOs;

namespace VaccineTurn.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<DailyRate> DailyRate { get; set; }
        public DbSet<PopulationGroups> PopulationGroups { get; set; }
        public DbSet<TotalVaccinations> TotalVaccinations { get; set; }
        public DbSet<Targets> Targets { get; set; }
        public DbSet<Users> Users { get; set; }

        public DbSet<FirstDosesByDate> FirstDosesByDate { get; set; }

        public DbSet<VaccineTurn.Data.DTOs.UserResultsDto> UserResultsDto { get; set; }

    }
}
