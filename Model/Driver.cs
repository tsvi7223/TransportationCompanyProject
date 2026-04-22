using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCompanyProject.Model
{
    public class Driver : User
    {
        public string DriverLicenseNumber { get; set; }    
        public Address CurrentLocation { get; set; }
        public Vehicle Vehicle { get; set; }
        public bool IsActive { get; set; }

        public Driver(string userPassword, string UserName, int Id,
            string lName, string fName, string phoneNumber, string emailAddress,
            DateTime dateOfBirth, Address address, string driverLicenseNumber, Address currentLocation, Vehicle vehicle, bool isActive)
            : base(userPassword, UserName, Id, lName, fName, phoneNumber, emailAddress, dateOfBirth, address)
        {
            this.DriverLicenseNumber = driverLicenseNumber;
            this.CurrentLocation = currentLocation;
            this.Vehicle = vehicle;
            this.IsActive = isActive;
        }
    }
}
