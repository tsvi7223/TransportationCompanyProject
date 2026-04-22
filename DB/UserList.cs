using System.Collections.Generic;
using System.Linq;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class UserList : List<User>
    {

        public UserList() { }

        public UserList(IEnumerable<User> list) : base(list) { }

        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת משתמשים
        public UserList(IEnumerable<BaseEntity> list) : base(list.Cast<User>().ToList()) { }
    }
}

