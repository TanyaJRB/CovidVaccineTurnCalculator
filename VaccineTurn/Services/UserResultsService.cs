using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineTurn.Data;
using VaccineTurn.Data.DTOs;
using VaccineTurn.Models;
using VaccineTurn.Services.Interfaces;

namespace VaccineTurn.Services
{
    public class UserResultsService : IUserResultsService 
    {
        private readonly AppDbContext _db;

        protected string yourPopulationGroup { get; set; }
        protected string currentPopulationGroup { get; set; }
        protected int peopleAhead { get; set; }
        protected int currentDailyRate { get; set; }
        protected int firstDosesToDate { get; set; }
        protected string earliestVaccineDate { get; set; }

        public UserResultsService(AppDbContext dbContext)
        {
            this._db = dbContext;
        }

        public dynamic[] findCurrentPopGroup()
        {
            PopulationGroups currentPopGroup = _db.PopulationGroups.Where(p => p.CurrentPopGroup == true).FirstOrDefault();
            int pgId = currentPopGroup.PopulationGroupsId;
            string phrase = $"The current population group is {currentPopGroup.AgeGroupMin} to {currentPopGroup.AgeGroupMax}.";

            this.currentPopulationGroup = phrase;

            dynamic[] a = { currentPopGroup, pgId, phrase };
            return a;
        }

        public int findNumberPeopleAhead(int age)
        {
            //FIND THE POPULATION GROUP OF THE USER AND THE CURRENT GOVERNMENT VACCINE SCHEME 

            var userPopGroup = _db.PopulationGroups.Where(p => p.AgeGroupMin <= age & age <= p.AgeGroupMax).FirstOrDefault();

            this.yourPopulationGroup = $"Your population group is {userPopGroup.AgeGroupMin} to {userPopGroup.AgeGroupMax}.";

            dynamic[] currentPopGroup = findCurrentPopGroup();

            // CALCULATE THE NUMBER OF PEOPLE IN THE POPULATION GROUPS BETWEEN THE CURRENT POPULATION GROUP AND THE USER'S GROUP 

            int totalAhead = 0;

            List<PopulationGroups> pgs = _db.PopulationGroups.ToList(); 

            for (int i = currentPopGroup[1]; i < pgs.Count();  i++)
            {
                if (pgs[i-1].AgeGroupMin <= userPopGroup.AgeGroupMin)
                {
                    break;
                }
                else
                {
                    totalAhead += pgs[i-1].NumberPeople;
                }
            }

            // CALCULATE THE NUMBER OF PEOPLE FROM THE CURRENT POPULATION GROUP THAT HAVE ALREADY BEEN VACCINATED TO DATE
            // AND ADD THE REMAINING NUMBER TO THE TOTAL INCLUDING THE PEOPLE FROM OTHER POPULATION GROUPS

            var numPeopleCurrentPopGroup = currentPopGroup[0].NumberPeople;

            DateTime announcementDate = currentPopGroup[0].DateOfAnnouncement;

            TotalVaccinations totalVaccsCurrentDateRow = _db.TotalVaccinations.Where(v => v.VaccType == "First Doses").First();

            int vaccinationsOnCurrentDate = totalVaccsCurrentDateRow.TotalDoses;

            this.firstDosesToDate = vaccinationsOnCurrentDate;

            int vaccinationsOnAnnouncementDate = _db.FirstDosesByDate.Where(v => v.CurrentDate == announcementDate).Select(v => v.TotalFirstDoses).First();

            int vaccinationsCompletedFromCurrentPopGroup = vaccinationsOnCurrentDate - vaccinationsOnAnnouncementDate;

            int vaccinationsRemainingInCurrentPopGroup = numPeopleCurrentPopGroup - vaccinationsCompletedFromCurrentPopGroup;

            if (totalAhead != 0)
            {
                totalAhead += vaccinationsRemainingInCurrentPopGroup;
            }
            
            this.peopleAhead = totalAhead;

            return totalAhead; 
        }

        public void calculateEarliestDate(int totalAhead, string currentOrTarget)
        {
            int dailyRate = 0; 

            if (currentOrTarget == "c")
            {
                dailyRate = _db.DailyRate.OrderByDescending(dr => dr.CurrentDate).Select(dr => dr.CurrentRate).First();
            }
            else if (currentOrTarget == "t")
            {
                dailyRate = _db.Targets.Find(1).TargetDailyRate;
            }
           
            this.currentDailyRate = dailyRate; 

            int daysRemaining = totalAhead / dailyRate;

            DateTime earliestDate = DateTime.Now.AddDays(daysRemaining);

            string earliestDateString = earliestDate.ToString("dd/MM/yyyy");

            if (totalAhead == 0)
            {
                earliestDateString = "NOW!";
            }

            this.earliestVaccineDate = earliestDateString;
        }

        public UserResultsDto GetUserResults(UsersDto udto, string currentOrTarget)
        {
            int totalAhead = findNumberPeopleAhead(udto.Age);

            calculateEarliestDate(totalAhead, currentOrTarget);

            var userResults = new UserResultsDto
            {
                UserId = udto.UserId,
                Age = udto.Age,
                YourPopulationGroup = this.yourPopulationGroup,
                CurrentPopulationGroup = this.currentPopulationGroup,
                PeopleAhead = this.peopleAhead.ToString("N0"),
                CurrentDailyRate = this.currentDailyRate.ToString("N0"),
                FirstDosesToDate = this.firstDosesToDate.ToString("N0"),
                EarliestVaccineDate = this.earliestVaccineDate
            };

            return userResults;
        }
    }
}
