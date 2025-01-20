using System;
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
                // Obtener la respuesta como una lista de objetos 'CountryApiResponse'
                var response = await _httpClient.GetFromJsonAsync<List<CountryApiResponse>>(url);

                if (response != null && response.Count > 0)
                {
                    var countryData = response[0]; // Tomamos el primer país de la lista

                    return new Country
                    {
                        NombreO = countryData.name.official,
                        Region = countryData.region,
                        GoogleMaps = countryData.maps.googleMaps
                    };
                }
                else
                {
                    // Si no encontramos el país, retornamos null
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                return null;
            }
        }
    }
}
