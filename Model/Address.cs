using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCompanyProject.Model
{
    public class Address:BaseEntity
    {
        //private string state;
        public City City { get; set; }
        public Street Street { get; set; }
        public string BuildingNumber { get; set; }

        public Address(int Id ,City city, Street street, string buildingNumber):base(Id)
        {
            this.City = city;
            this.Street = street;
            this.BuildingNumber = buildingNumber;
        }

        public Address()
            :base(0)
        {
        }
    }
}
