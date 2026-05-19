using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    [CollectionDataContract(Name = "PeopleList", ItemName = "Person")]
    public class PeopleList : List<Person>
    {


        public PeopleList() { }

        public PeopleList(IEnumerable<Person> list) : base(list) { }

        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת אנשים
        public PeopleList(IEnumerable<BaseEntity> list) : base(list.Cast<Person>().ToList()) { }
    }
}
//using System.Collections.Generic;
 //using System.Linq;
 //using TransportationCompanyProject.Model;

//namespace TransportationCompanyProject.DB
//{
//    public class PeopleList : List<Person>
//    {


//        public PeopleList() { }

//        public PeopleList(IEnumerable<Person> list) : base(list) { }

//        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת אנשים
//        public PeopleList(IEnumerable<BaseEntity> list) : base(list.Cast<Person>().ToList()) { }
//    }
//}