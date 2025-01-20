using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillalbaExamenProgreso3.Models
{
    public class Country
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NombreO { get; set; }

        public string Region { get; set; }
        public string GoogleMaps { get; set; }

        public string NombreE { get; set; }

    }
}
