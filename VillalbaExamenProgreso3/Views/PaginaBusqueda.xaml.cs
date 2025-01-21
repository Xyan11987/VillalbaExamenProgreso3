using VillalbaExamenProgreso3.ViewModels;
using VillalbaExamenProgreso3.Services;
using Microsoft.Maui.Controls;
using System.IO;

namespace VillalbaExamenProgreso3.Views
{
    public partial class PaginaBusqueda : ContentPage
    {
        public PaginaBusqueda()
        {
            InitializeComponent();

            
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "countries.db3");

            
            var viewModel = new SearchViewModel(dbPath);
            BindingContext = viewModel;
        }
    }
}
