using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillalbaExamenProgreso3.Services
{
    public class ServiceCountry
    {

        private readonly HttpClient _httpClient;

        public ServiceCountry() {
        
            _httpClient = new HttpClient();

        }


    }
}
