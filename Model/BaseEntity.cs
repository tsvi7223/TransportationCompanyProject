using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCompanyProject.Model
{
    public class BaseEntity
    {
        public int Id { get; set; } = 0;
        public BaseEntity(int Id)
        {
            this.Id = Id;
        }
        
    }
}
