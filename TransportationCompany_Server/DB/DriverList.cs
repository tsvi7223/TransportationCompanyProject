using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    [CollectionDataContract(Name = "DriverList", ItemName = "Driver")]
    public class DriverList : List<Driver>
    {

        public DriverList() { }

        public DriverList(IEnumerable<Driver> list) : base(list) { }

        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת נהגים
        public DriverList(IEnumerable<BaseEntity> list) : base(list.Cast<Driver>().ToList()) { }
    }
}

//using System.Collections.Generic;
//using System.Linq;
//using TransportationCompanyProject.Model;

//namespace TransportationCompanyProject.DB
//{
//    public class DriverList : List<Driver>
//    {

//        public DriverList() { }

//        public DriverList(IEnumerable<Driver> list) : base(list) { }

//        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת נהגים
//        public DriverList(IEnumerable<BaseEntity> list) : base(list.Cast<Driver>().ToList()) { }
//    }
//}

