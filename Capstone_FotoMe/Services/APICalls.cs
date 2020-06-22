using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Capstone_FotoMe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;

namespace Capstone_FotoMe.Services
{
    
    public class APICalls : IAPIService
    {
        public async Task<GeoCode> Geocoding(string address)
        {
            string url = //find the url and api key for this 

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<GeoCode>(json);

            }

            return null;

        }


    }

   

}
