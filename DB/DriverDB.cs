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
            command.CommandText = $" SELECT People.*, Users.*, Drivers.*" +
                $" FROM((People INNER JOIN Users ON People.PersonId = Users.UserId) " +
                $"INNER JOIN Drivers ON Users.UserId = Drivers.DriverId)";
            return new DriverList(base.Select());
        }

        public Driver SelectById(int id)
        {
            command.CommandText = $" SELECT People.*, Users.*, Drivers.*" +
               $" FROM((People INNER JOIN Users ON People.PersonId = Users.UserId) " +
               $"INNER JOIN Drivers ON Users.UserId = Drivers.DriverId) WHERE(Drivers.DriverId = {id})";

            DriverList  drivers = new DriverList(base.Select());
            try
            {
                return drivers[0];
            }
                catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message+ " driversdb is null");
            }
              
            return null;
            
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
            command.CommandText = $"INSERT INTO Drivers (DriverId, DriverLicenseNumber, CurrentLocationId, VehicleId, IsActive) " +
                $"VALUES({driver.Id}, {driver.DriverLicenseNumber}, {driver.CurrentLocation}, {driver.Vehicle}, {driver.IsActive}))";
            base.ExecuteNonQuery();
            base.Insert(driver);
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

            return driver;
        }

        protected override BaseEntity NewEntity()
        {
            return new Driver();
        }
    }
}

