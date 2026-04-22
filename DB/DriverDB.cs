using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class DriverDB : BaseDB
    {

        private static DriverDB instance;

        private DriverDB() { }

        public static DriverDB GetInstance()
        {
            if (instance == null)
                instance = new DriverDB();
            return instance;
        }

        public void Delete(Driver driver)
        {
            command.CommandText = $"DELETE FROM Drivers WHERE(Drivers.driverId = {driver.Id})";
            base.ExecuteNonQuery();
        }

        public DriverList SelectAll()
        {
            command.CommandText = "SELECT * FROM Drivers";
            return new DriverList(base.Select());
        }

        public Driver SelectById(int id)
        {
            command.CommandText = $"SELECT * FROM Drivers WHERE (Drivers.driverId = {id})";
        
                DriverList drivers = null;
                command.CommandText = $"SELECT * FROM Drivers WHERE DriverId = {id}";
                try
                {
                    drivers = new DriverList(base.Select());
                }
                catch (Exception e)
                {
                    Console.WriteLine("error: " + e.Message);
                }
                return drivers[0];

            
        }

        public void Update(Driver driver)
        {
            command.CommandText = $"UPDATE Drivers SET driverId = {driver.Id}, " +
                $"firstName = '{driver.fName}', lastname = '{driver.lName}', " +
                $"phoneNumber = '{driver.phoneNumber}', emailAddress = '{driver.emailAddress}', " +
                $"dateOfBirth = #{driver.dateOfBirth}#, addressId = {driver.address.Id}, " +
                $"userName = '{driver.UserName}', userPassword = '{driver.UserPassword}', " +
                $"driverLicenseNumber = '{driver.DriverLicenseNumber}', " +
                $"currentLocationId = {driver.CurrentLocation.Id}, vehicleId = {driver.Vehicle.Id}, " +
                $"isActive = {driver.IsActive} WHERE driverId = {driver.Id}";

            base.ExecuteNonQuery();
        }

        public void Insert(Driver driver)
        {
            command.CommandText = $"INSERT INTO Drivers (driverId, firstName, lastname, phoneNumber, emailAddress, dateOfBirth, addressId, userName, userPassword, driverLicenseNumber, currentLocationId, vehicleId, isActive)" +
                $"VALUES({driver.Id}, '{driver.fName}', '{driver.lName}', '{driver.phoneNumber}', '{driver.emailAddress}', " +
                $"#{driver.dateOfBirth}#, {driver.address.Id}, '{driver.UserName}', '{driver.UserPassword}', " +
                $"'{driver.DriverLicenseNumber}', {driver.CurrentLocation.Id}, {driver.Vehicle.Id}, {driver.IsActive})";
            base.ExecuteNonQuery();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Driver driver = entity as Driver;

            driver.Id = int.Parse(reader["driverId"].ToString());
            driver.DriverLicenseNumber = reader["driverLicenseNumber"].ToString();
            driver.IsActive = bool.Parse(reader["isActive"].ToString());

            int currentLocationId = int.Parse(reader["currentLocationId"].ToString());
            driver.CurrentLocation = AddressDB.GetInstance().SelectById(currentLocationId);
            int vehicleId = int.Parse(reader["vehicleId"].ToString());
            driver.Vehicle = VehicleDB.GetInstance().SelectById(vehicleId);
           

            User user1 = driver as User;
            User user = UserDB.GetInstance().SelectById(driver.Id);
            user1.Copy(user);
            /*
                        string fName = reader["firstName"].ToString();
                        string lName = reader["lastname"].ToString();
                        string phoneNumber = reader["phoneNumber"].ToString();
                        string emailAddress = reader["emailAddress"].ToString();
                        DateTime dateOfBirth = (DateTime)reader["dateOfBirth"];
                        int addressId = int.Parse(reader["addressId"].ToString());
                        string userName = reader["userName"].ToString();
                        string userPassword = reader["userPassword"].ToString();
                        // יצירת אובייקטים - יש להשלים עם שליפות מהטבלאות המתאימות
                        Address address = new Address(addressId, new City(0, ""), new Street(0, ""), "");
                        Address currentLocation = new Address(currentLocationId, new City(0, ""), new Street(0, ""), "");
                        Vehicle vehicle = new Vehicle(vehicleId, "", 0, "", "");
            */
            return driver as BaseEntity;
        }

        protected override BaseEntity NewEntity()
        {
            return new Driver("", "", 0, "", "", "", "", DateTime.Now, 
                new Address(0, new City(0, ""), new Street(0, ""), ""), "", 
                new Address(0, new City(0, ""), new Street(0, ""), ""), 
                new Vehicle(0, "", 0, "", ""), false);
        }
    }
}

