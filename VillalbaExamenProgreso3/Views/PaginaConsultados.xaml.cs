using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using VillalbaExamenProgreso3.ViewModels;

namespace VillalbaExamenProgreso3.Views
{
    public partial class PaginaConsultados : ContentPage
    {
        public PaginaConsultados()
        {
            InitializeComponent();
            BindingContext = new ConsultedCountriesViewModel();
        }

       
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ((ConsultedCountriesViewModel)BindingContext).LoadCountries();
        }
    }
}
