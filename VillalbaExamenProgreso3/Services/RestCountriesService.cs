using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VillalbaExamenProgreso3.Models;

namespace VillalbaExamenProgreso3.Services
{
    public class RestCountriesService
    {
        private readonly HttpClient _httpClient;

        public RestCountriesService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Country?> GetCountryByName(string countryName)
        {
            var url = $"https://restcountries.com/v3.1/name/{countryName}?fields=name,region,maps";

            try
            {
                // Realiza la solicitud a la API
                var response = await _httpClient.GetFromJsonAsync<List<dynamic>>(url);
                if (response?.Count > 0)
                {
                    var countryData = response[0];

                    // Crear y devolver un objeto Country con los datos obtenidos
                    return new Country
                    {
                        NombreO = countryData.name.official,
                        Region = countryData.region,
                        GoogleMaps = countryData.maps.googleMaps
                    };
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
            }

            return null;
        }
    }
}
