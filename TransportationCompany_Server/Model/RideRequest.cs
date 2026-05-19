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
    public class RideRequest : BaseEntity
    {

        [DataMember]
        public Customer Customer { get; set; }

        [DataMember]
        public Address PickupAddress { get; set; }

        [DataMember]
        public Address DestinationAddress { get; set; }

        [DataMember]
        public DateTime RequestTime { get; set; }

        [DataMember]
        public DateTime ScheduledTime { get; set; }

        [DataMember]
        public int NumberOfPassengers { get; set; }

        [DataMember]
        public RequestStatus Status { get; set; }

        public RideRequest(int Id, Customer customer,
            Address pickupAddress, Address destinationAddress,
            DateTime requestTime, DateTime scheduledTime,
            int numberOfPassengers, RequestStatus status) : base(Id)
        {

            this.Customer = customer;
            this.PickupAddress = pickupAddress;
            this.DestinationAddress = destinationAddress;
            this.RequestTime = requestTime;
            this.ScheduledTime = scheduledTime;
            this.NumberOfPassengers = numberOfPassengers;
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
//    public class RideRequest:BaseEntity
//    {

//        public Customer Customer { get; set; }
//        public Address PickupAddress { get; set; }
//        public Address DestinationAddress { get; set; }
//        public DateTime RequestTime { get; set; }
//        public DateTime ScheduledTime { get; set; }
//        public int NumberOfPassengers { get; set; }
//        public RequestStatus Status { get; set; }

//        public RideRequest(int Id, Customer customer, 
//            Address pickupAddress, Address destinationAddress, 
//            DateTime requestTime, DateTime scheduledTime, 
//            int numberOfPassengers, RequestStatus status):base(Id)
//        {

//            this.Customer = customer;
//            this.PickupAddress = pickupAddress;
//            this.DestinationAddress = destinationAddress;
//            this.RequestTime = requestTime;
//            this.ScheduledTime = scheduledTime;
//            this.NumberOfPassengers = numberOfPassengers;
//            this.Status = status;
//        }
//    }
//}

