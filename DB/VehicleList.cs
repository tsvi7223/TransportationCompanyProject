using System.Collections.Generic;
using System.Linq;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class VehicleList : List<Vehicle>
    {

        public VehicleList() { }

        public VehicleList(IEnumerable<Vehicle> list) : base(list) { }

        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת כלי רכב
        public VehicleList(IEnumerable<BaseEntity> list) : base(list.Cast<Vehicle>().ToList()) { }
    }
}

