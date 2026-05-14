using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCompanyProject.Model
{
    public class Ride:BaseEntity
    {
       
        public RideRequest RideRequest { get; set; }
        public Driver Driver { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public RideStatus Status { get; set; }
        public double Price { get; set; }
        
       

        public Ride(int Id, RideRequest rideRequest, Driver driver, 
            DateTime startTime, DateTime endTime, RideStatus status, double price):base(Id)
        {
            
            this.RideRequest = rideRequest;
            this.Driver = driver;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Status = status;
            this.Price = price;
        }
    }
}
