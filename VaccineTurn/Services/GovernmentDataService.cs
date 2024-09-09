using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using VaccineTurn.Data;
using VaccineTurn.Models;
using VaccineTurn.Services.Interfaces;

namespace VaccineTurn.Services
{
    public class GovernmentDataService : IGovernmentDataService
    {
        private readonly AppDbContext _db;

        public GovernmentDataService(AppDbContext dbContext)
        {
            this._db = dbContext;
        }

        public async Task<dynamic> GetGovData(string baseUrl)
        {
            HttpClientHandler clientHandler = new HttpClientHandler()
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip
            };

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            try
            {
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string responseDataString = await content.ReadAsStringAsync();

                            if (responseDataString != null)
                            {
                                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseDataString).data;
                                return dynamicObject;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task GetTotalDoses(int id)
        {
            string doseUrl = ""; 

            if (id == 1)
            {
                doseUrl = "https://api.coronavirus.data.gov.uk/v1/data?filters=areaType=overview&structure={%22date%22:%22date%22,%20%22totalDoses%22:%22cumPeopleVaccinatedFirstDoseByPublishDate%22}";
            }
            else if (id == 2)
            {
                doseUrl = "https://api.coronavirus.data.gov.uk/v1/data?filters=areaType=overview&structure={%22date%22:%22date%22,%20%22totalDoses%22:%22cumPeopleVaccinatedSecondDoseByPublishDate%22}";
            }
            else if (id == 3)
            {
                doseUrl = "https://api.coronavirus.data.gov.uk/v1/data?filters=areaType=overview&structure={%22date%22:%22date%22,%22totalDoses%22:%22cumPeopleVaccinatedCompleteByPublishDate%22}";
            }

            var dynamicData = await GetGovData(doseUrl);
           
            dynamic dataToday = dynamicData[0];

            var currentDate = DateTime.ParseExact(dataToday.date.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var statToUpdate = _db.TotalVaccinations.Find(id);

            statToUpdate.CurrentDate = currentDate;
            statToUpdate.TotalDoses = dataToday.totalDoses;

            _db.SaveChanges();
        }

        public async Task GetDailyRate()
        {
            string doseUrl = "https://api.coronavirus.data.gov.uk/v1/data?filters=areaType=overview&structure={%22date%22:%22date%22,%22newFirstDoses%22:%22newPeopleVaccinatedFirstDoseByPublishDate%22}";

            var dynamicData = await GetGovData(doseUrl);

            foreach(DailyRate dr in _db.DailyRate)
            {
                _db.Remove(dr);
            }

            foreach (dynamic dataToday in dynamicData)
            {
                var dataDate = DateTime.ParseExact(dataToday.date.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var newFirstDoses = dataToday.newFirstDoses;
                
                var newRateFigure = new DailyRate
                {
                    CurrentDate = dataDate,
                    CurrentRate = newFirstDoses
                };

                _db.Add(newRateFigure);
            }

            //for (int i=0; i<dynamicData.Count; i++)
            //{ }

            _db.SaveChanges();
        }

        public async Task GetFirstDosesByDate()
        {
            string doseUrl = "https://api.coronavirus.data.gov.uk/v1/data?filters=areaType=overview&structure={%22date%22:%22date%22,%20%22totalDoses%22:%22cumPeopleVaccinatedFirstDoseByPublishDate%22}";
            
            var dynamicData = await GetGovData(doseUrl);

            foreach (FirstDosesByDate fd in _db.FirstDosesByDate)
            {
                _db.Remove(fd);
            }

            foreach (dynamic dataToday in dynamicData)
            {
                var dataDate = DateTime.ParseExact(dataToday.date.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var firstDoses = dataToday.totalDoses;

                var fd = new FirstDosesByDate
                {
                    CurrentDate = dataDate,
                    TotalFirstDoses = firstDoses
                };

                _db.Add(fd);

            }
            
            _db.SaveChanges();
        }



    }
}
