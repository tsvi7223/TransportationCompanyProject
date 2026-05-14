using System.Collections.Generic;
using System.Linq;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class RideList : List<Ride>
    {

        public RideList() { }

        public RideList(IEnumerable<Ride> list) : base(list) { }

        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת נסיעות
        public RideList(IEnumerable<BaseEntity> list) : base(list.Cast<Ride>().ToList()) { }
    }
}

