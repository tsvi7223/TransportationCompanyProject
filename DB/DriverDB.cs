using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class DriverDB : UserDB
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
            base.Delete(driver); // מחיקת האדם מהטבלה People
        }

        public DriverList SelectAll()
        {
            command.CommandText = $"SELECT Drivers.*, Users.*, People.* FROM   " +
                $"((Drivers " +
                     $"INNER JOIN  Users ON Drivers.DriverId = Users.UserId) " +
                          $"INNER JOIN  People ON Users.UserId = People.PersonId)";
            return new DriverList(base.Select());
        }

        public Driver SelectById(int id)
        {
            command.CommandText = "SELECT Drivers.*, Users.*, People.* FROM   " +
                $"((Drivers " +
                     $"INNER JOIN  Users ON Drivers.DriverId = Users.UserId) " +
                          $"INNER JOIN  People ON Users.UserId = People.PersonId) " +
                $"WHERE  (Drivers.DriverId = {id})";
        
                DriverList drivers = null;
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
            //TODO: עדכון צריך להתבצע בשתי טבלאות - גם ב-Drivers וגם ב-Users, כרגע מתעדכן רק ב-Drivers
            command.CommandText = $"driverLicenseNumber = '{driver.DriverLicenseNumber}', " +
                $"currentLocationId = {driver.CurrentLocation.Id}, vehicleId = {driver.Vehicle.Id}, " +
                $"isActive = {driver.IsActive} WHERE driverId = {driver.Id}";

            base.ExecuteNonQuery();
            base.Update(driver);
        }

        public void Insert(Driver driver)
        {///J
            //TODO: הוספה צריכה להתבצע בשתי טבלאות - גם ב-Drivers וגם ב-Users, כרגע מתבצעת רק ב-Drivers
            command.CommandText = $"INSERT INTO Drivers (DriverId, DriverLicenseNumber, CurrentLocationId, VehicleId, IsActive) VALUES(3, '3', 3, 3, 3))";
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

            base.CreateModel(driver);


            //User user1 = driver as User;
            //User user = UserDB.GetInstance().SelectById(driver.Id);
            //user1.Copy(user);
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

