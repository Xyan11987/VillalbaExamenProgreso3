using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillalbaExamenProgreso3.Models
{
    public class CountryApiResponse
    {
        public Name name { get; set; }
        public string region { get; set; }
        public Maps maps { get; set; }
    }

    public class Name
    {
        public string official { get; set; }
    }

    public class Maps
    {
        public string googleMaps { get; set; }
    }
}
