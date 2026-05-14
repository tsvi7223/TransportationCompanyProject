using System.Collections.Generic;
using System.Linq;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class CustomerList : List<Customer>
    {

        public CustomerList() { }

        public CustomerList(IEnumerable<Customer> list) : base(list) { }

        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת לקוחות
        public CustomerList(IEnumerable<BaseEntity> list) : base(list.Cast<Customer>().ToList()) { }
    }
}

