using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VillalbaExamenProgreso3.Models;
using VillalbaExamenProgreso3.Services;

namespace VillalbaExamenProgreso3.ViewModels
{
    public class ConsultedCountriesViewModel : BaseViewModel
    {
        private readonly DatabaseService _databaseService;

        public ObservableCollection<Country> Countries { get; } = new();

        public Command RefreshCommand { get; }

        public ConsultedCountriesViewModel()
        {
            
            _databaseService = new DatabaseService(App.DatabasePath);

            RefreshCommand = new Command(async () => await LoadCountries());
            LoadCountries().ConfigureAwait(false);
        }

        private async Task LoadCountries()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                Countries.Clear();

                var countriesFromDb = await _databaseService.GetCountriesAsync();
                foreach (var country in countriesFromDb)
                {
                    Countries.Add(country);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
