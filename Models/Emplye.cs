using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace variant_14_4.Models
{
    public class Employe
    {
        public int Id { get; set; }         // number
        public string Name { get; set; }    // max length 128
        public City City { get; set; }      // has one city
        public int CityId { get; set; }     // foreign key
    }
}
