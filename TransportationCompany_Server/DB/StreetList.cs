using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    [CollectionDataContract(Name = "StreetList", ItemName = "Street")]
    public class StreetList : List<Street>
    {

        public StreetList() { }

        public StreetList(IEnumerable<Street> list) : base(list) { }

        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת רחובות
        public StreetList(IEnumerable<BaseEntity> list) : base(list.Cast<Street>().ToList()) { }
    }
}
//using System.Collections.Generic;
//using System.Linq;
//using TransportationCompanyProject.Model;

//namespace TransportationCompanyProject.DB
//{
//    public class StreetList : List<Street>
//    {

//        public StreetList() { }

//        public StreetList(IEnumerable<Street> list) : base(list) { }

//        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת רחובות
//        public StreetList(IEnumerable<BaseEntity> list) : base(list.Cast<Street>().ToList()) { }
//    }
//}

