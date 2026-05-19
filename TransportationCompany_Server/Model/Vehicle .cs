using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCompanyProject.Model
{
    [DataContract]
    public class Vehicle : BaseEntity
    {
        [DataMember]
        public string VehicleType { get; set; }

        [DataMember]
        public int Capacity { get; set; }

        [DataMember]
        public string LicensePlate { get; set; }

        [DataMember]
        public string Status { get; set; }


        public Vehicle(int Id, string vehicleType, int capacity, string licensePlate, string status) : base(Id)
        {
            this.VehicleType = vehicleType;
            this.Capacity = capacity;
            this.LicensePlate = licensePlate;
            this.Status = status;
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
//    public class Vehicle:BaseEntity
//    {

//       public string VehicleType { get; set; }
//       public int Capacity { get; set; }
//       public string LicensePlate { get; set; }
//       public string Status { get; set; }


//        public Vehicle(int Id, string vehicleType, int capacity, string licensePlate, string status):base(Id)
//        {

//            this.VehicleType = vehicleType;
//            this.Capacity = capacity;
//            this.LicensePlate = licensePlate;
//            this.Status = status;
//        }
//    }
//}
