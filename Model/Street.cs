using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCompanyProject.Model
{
    public class Street:BaseEntity
    {
        public string StreetName { get; set; }
        
        public Street(int Id,string streetName):base(Id)
        {
            this.StreetName = streetName;
        
        }
        public Street()
           : base(0)
        {
        }
    }
}
