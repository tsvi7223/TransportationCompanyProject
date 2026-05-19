using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransportationCompanyProject.DB;
using TransportationCompanyProject.Model;

namespace TransportationCompany_Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Transportation_service : ITransportation_service
    {
        public void Delete(City city)
        {
           CityDB.GetInstance().Delete(city);
        }

        public UserList getAllUsers()
        {
            return UserDB.GetInstance().SelectAll();
        }
    
        public UserList SelectByUserProprty(string name, string pass)
        {
            return UserDB.GetInstance().SelectByUserProprty(name, pass );
        }
    }
}
