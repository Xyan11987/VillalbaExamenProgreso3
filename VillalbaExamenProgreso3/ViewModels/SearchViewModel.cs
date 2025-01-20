using MvvmHelpers;
using System.Threading.Tasks;
using System.Windows.Input;
using VillalbaExamenProgreso3.Models;
using VillalbaExamenProgreso3.Services;

namespace VillalbaExamenProgreso3.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly RestCountriesService _restService;
        private readonly DatabaseService _databaseService;

        public string CountryName { get; set; }

        public ICommand SearchCommand { get; }
        public ICommand ClearCommand { get; }

        public SearchViewModel(string dbPath)
        {
            _restService = new RestCountriesService();
            _databaseService = new DatabaseService(dbPath);

            SearchCommand = new Command(async () => await SearchCountry());
            ClearCommand = new Command(ClearFields); 
        }

        private async Task SearchCountry()
        {
            if (string.IsNullOrWhiteSpace(CountryName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ingrese un país para buscar.", "OK");
                return;
            }

            // Verificar que el país se esté enviando correctamente
            Console.WriteLine($"Buscando el país: {CountryName}");

            var country = await _restService.GetCountryByName(CountryName);

            if (country != null)
            {
                country.NombreE = "SCordova"; 
                await _databaseService.SaveCountryAsync(country); 
                await Application.Current.MainPage.DisplayAlert("Éxito",
                    $"País: {country.NombreO}\nRegión: {country.Region}\nGoogle Maps: {country.GoogleMaps}",
                    "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "País no encontrado.", "OK");
            }
        }



        private void ClearFields()
        {
            CountryName = string.Empty; 
            OnPropertyChanged(nameof(CountryName)); 
        }
    }
}
