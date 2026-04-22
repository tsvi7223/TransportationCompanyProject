using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCompanyProject.Model
{
    public class City:BaseEntity
    {
       
        public string CityName { get; set; }
        public City(int Id, string cityName):base(Id)
        {
            this.CityName = cityName;
        }
    }
}
