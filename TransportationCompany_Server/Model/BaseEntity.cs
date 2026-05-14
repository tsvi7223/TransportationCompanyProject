using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCompanyProject.Model
{
    [DataContract]
    public class BaseEntity
    {
        [DataMember]
        public int Id { get; set; } = 0;

        public BaseEntity(int Id)
        {
            this.Id = Id;
        }

        public BaseEntity()
        {

        }
    }
}
//using System;
 //using System.Collections.Generic;
 //using System.Linq;
 //using System.Text;
 //using System.Threading.Tasks;

//namespace TransportationCompanyProject.Model
//{
//    public class BaseEntity
//    {
//        public int Id { get; set; } = 0;
//        public BaseEntity(int Id)
//        {
//            this.Id = Id;
//        }

//    }
//}
