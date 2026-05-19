using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    [CollectionDataContract(Name = "CustomerList", ItemName = "Customer")]
    public class CustomerList : List<Customer>
    {

        public CustomerList() { }

        public CustomerList(IEnumerable<Customer> list) : base(list) { }

        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת לקוחות
        public CustomerList(IEnumerable<BaseEntity> list) : base(list.Cast<Customer>().ToList()) { }
    }
}

//using System.Collections.Generic;
//using System.Linq;
//using TransportationCompanyProject.Model;

//namespace TransportationCompanyProject.DB
//{
//    public class CustomerList : List<Customer>
//    {

//        public CustomerList() { }

//        public CustomerList(IEnumerable<Customer> list) : base(list) { }

//        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת לקוחות
//        public CustomerList(IEnumerable<BaseEntity> list) : base(list.Cast<Customer>().ToList()) { }
//    }
//}

