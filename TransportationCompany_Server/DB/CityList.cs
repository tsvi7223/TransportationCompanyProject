using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    [CollectionDataContract(Name = "CityList", ItemName = "City")]
    public class CityList : List<City>
    {

        public CityList() { }

        public CityList(IEnumerable<City> list) : base(list) { }

        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת ערים
        public CityList(IEnumerable<BaseEntity> list) : base(list.Cast<City>().ToList()) { }
    }
}

//using System.Collections.Generic;
//using System.Linq;
//using TransportationCompanyProject.Model;

//namespace TransportationCompanyProject.DB
//{
//    public class CityList : List<City>
//    {

//        public CityList() { }

//        public CityList(IEnumerable<City> list) : base(list) { }

//        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת ערים
//        public CityList(IEnumerable<BaseEntity> list) : base(list.Cast<City>().ToList()) { }
//    }
//}

