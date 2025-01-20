using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VillalbaExamenProgreso3.Services;
using VillalbaExamenProgreso3.Services;
using VillalbaExamenProgreso3.Models;

namespace VillalbaExamenProgreso3.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly RestCountriesService _restService;

        public string CountryName { get; set; }

        public ICommand SearchCommand { get; }
        public ICommand ClearCommand { get; }

        public SearchViewModel()
        {
            _restService = new RestCountriesService();

            SearchCommand = new Command(async () => await SearchCountry());
            ClearCommand = new Command(() => CountryName = string.Empty);
        }

        private async Task SearchCountry()
        {
            if (string.IsNullOrWhiteSpace(CountryName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ingrese un país para buscar.", "OK");
                return;
            }

            var country = await _restService.GetCountryByName(CountryName);

            if (country != null)
            {
                country.NombreE = "Dvillalba"; 
                await Application.Current.MainPage.DisplayAlert("Éxito",
                    $"País: {country.NombreO}\nRegión: {country.Region}\nGoogle Maps: {country.GoogleMaps}",
                    "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "País no encontrado.", "OK");
            }
        }
    }
}


