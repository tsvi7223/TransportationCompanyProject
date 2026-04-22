using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCompanyProject.Model
{
    public class Manager : User
    {
        public Manager(string userPassword, string UserName, int Id,
            string lName, string fName, string phoneNumber, string emailAddress,
            DateTime dateOfBirth, Address address)
            : base(userPassword, UserName, Id, lName, fName, phoneNumber, emailAddress, dateOfBirth, address)
        {
        }
    }
}

