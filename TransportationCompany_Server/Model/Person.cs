using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCompanyProject.Model
{
    public abstract class Person : BaseEntity
    {

       public string lName { get; set; }
       public string fName { get; set; }
       public string phoneNumber { get; set; }
       public Address address { get; set; }
       public string emailAddress { get; set; }
       public DateTime dateOfBirth { get; set; }


        public Person(int Id, string lName, string fName, string phoneNumber, string emailAddress, DateTime dateOfBirth, Address address)
        : base(Id)
        {
            
            this.lName = lName;
            this.fName = fName;
            this.phoneNumber = phoneNumber;
            this.emailAddress = emailAddress;
            this.dateOfBirth = dateOfBirth;
            this.address = address;
        }

        public Person()
            :base(0)
        {
            this.lName = String.Empty;
            this.fName = String.Empty;
            this.phoneNumber = String.Empty;
            this.emailAddress = String.Empty;
            this.dateOfBirth = new DateTime();
            this.address = new Address();
        }

        //public void Copy(Person other)
        //{
        //    this.lName = other.lName;
        //    this.fName = other.fName;
        //    this.phoneNumber = other.phoneNumber;
        //    this.emailAddress = other.emailAddress;
        //    this.dateOfBirth = other.dateOfBirth;
        //    this.address = other.address;
      
        //}
        
    }
}
