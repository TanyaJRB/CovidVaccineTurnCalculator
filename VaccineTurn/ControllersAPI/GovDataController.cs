using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace VaccineTurn.ControllersAPI
{
    public class GovDataController : Controller
    {
        public GovDataController()
        {

        }

        [HttpGet("newfirstdoses")]
        public async Task<ActionResult<FirstDoses>> Get()
        {
            //dynamic result;

            try
            {
                using (var client = new HttpClient())
                {
                    string url = string.Format("https://api.coronavirus.data.gov.uk/v1/data?filters=areaType=overview&structure={%22date%22:%22date%22,%20%22totalFirstDoses%22:%22cumPeopleVaccinatedFirstDoseByPublishDate%22}");
                    var response = client.GetAsync(url).Result;

                    string responseAsString = await response.Content.ReadAsStringAsync();
                    //dynamic result.data = JsonConvert.DeserializeObject<dynamic>(responseAsString); //dynamic types 
                }
            }
            catch (System.Exception)
            {
                throw;
            }

            return Ok(/*result*/);
        }
    }

    public class FirstDoses
    {
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("newFirstDoses")]
        public ValueModel NewFirstDoses { get; set; }
    }

    public class ValueModel
    {
        [JsonProperty("value")]
        public int Value { get; set; }
    }

}
