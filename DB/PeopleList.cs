using System.Collections.Generic;
using System.Linq;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class PeopleList : List<Person>
    {


        public PeopleList() { }

        public PeopleList(IEnumerable<Person> list) : base(list) { }

        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת אנשים
        public PeopleList(IEnumerable<BaseEntity> list) : base(list.Cast<Person>().ToList()) { }
    }
}