using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineTurn.Data;
using VaccineTurn.Models;
using VaccineTurn.Services.Interfaces;

namespace VaccineTurn.Services
{
    public class TargetService : ITargetService
    {
        private readonly AppDbContext _db;

        public TargetService(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public int CalculateTargetDailyRate()
        {
          
            TotalVaccinations current = _db.TotalVaccinations.Find(1);
            Targets target = _db.Targets.Find(1);

            int currentFirstDoses = current.TotalDoses;
            int targetFirstDoses = target.TargetFirstDoses;
            int dosesRemaining = targetFirstDoses - currentFirstDoses;

            DateTime currentDate = current.CurrentDate;
            DateTime targetDate = target.TargetDate;

            TimeSpan dr = targetDate.Subtract(currentDate);
            int daysRemaining = int.Parse(dr.Days.ToString());

            int targetDailyRate = dosesRemaining / daysRemaining;
            int targetWeeklyRate = targetDailyRate * 7; 

            target.TargetDailyRate = targetDailyRate;
            target.TargetWeeklyRate = targetWeeklyRate;

            _db.SaveChanges();

            return targetDailyRate;

        }


    }
}
