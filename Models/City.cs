using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace variant_14_4.Models
{
    public class City
    {
        public int Id { get; set; }                        // number
        public string Name { get; set; }                   // max length 128
        public int Latitude { get; set; }                  // number
        public int Longitude { get; set; }                 // number
        public ICollection<Employe> Employes { get; set; } // has many Employes

    }
}
