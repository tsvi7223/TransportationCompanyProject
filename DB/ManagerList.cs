using System.Collections.Generic;
using System.Linq;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class ManagerList : List<Manager>
    {

        public ManagerList() { }

        public ManagerList(IEnumerable<Manager> list) : base(list) { }

        // המרה מרשימה של BaseEntity (מה שחוזר מה-DB) לרשימת מנהלים
        public ManagerList(IEnumerable<BaseEntity> list) : base(list.Cast<Manager>().ToList()) { }
    }
}

