using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VillalbaExamenProgreso3.Models;

namespace VillalbaExamenProgreso3.Services
{
    public class RestCountriesService
    {

        private readonly HttpClient _httpClient;

        public RestCountriesService() {
        
            _httpClient = new HttpClient();

        }

        public async Task<Country?> GetCountryByName(string countryName)
        {

            var url = $"https://restcountries.com/v3.1/name/%7bname%7d";
                try
                {
                    var response = await _httpClient.GetFromJsonAsync<List<dynamic>>(url);
                    if (response?.Count > 0)
                    {
                        var countryData = response[0];
                        return new Country
                        {

                            NombreO = countryData.name.official,
                            Region = countryData.region,
                            GoogleMaps = countryData.maps.googleMaps,

                        };
                    }
                }
                catch
            {
               
            }
            return null;
        }

    }
}
