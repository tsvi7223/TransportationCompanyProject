using System.Collections.Generic;
using System.Linq;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class AddressList : List<Address>
    {

        public AddressList() { }

        public AddressList(IEnumerable<Address> list) : base(list) { }

        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת כתובות
        public AddressList(IEnumerable<BaseEntity> list) : base(list.Cast<Address>().ToList()) { }
    }
}

