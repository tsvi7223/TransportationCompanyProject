using System.Collections.Generic;
using System.Linq;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class RideRequestList : List<RideRequest>
    {

        public RideRequestList() { }

        public RideRequestList(IEnumerable<RideRequest> list) : base(list) { }

        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת בקשות נסיעה
        public RideRequestList(IEnumerable<BaseEntity> list) : base(list.Cast<RideRequest>().ToList()) { }
    }
}

