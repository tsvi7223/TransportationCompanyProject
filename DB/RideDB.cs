using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class RideDB : BaseDB
    {

        private static RideDB instance;

        private RideDB() { }

        public static RideDB GetInstance()
        {
            if (instance == null)
                instance = new RideDB();
            return instance;
        }

        public void Delete(Ride ride)
        {
            command.CommandText = $"DELETE FROM Rides WHERE(Rides.rideId = {ride.Id})";
            base.ExecuteNonQuery();
        }

        public RideList SelectAll()
        {
            command.CommandText = "SELECT * FROM Rides";
            return new RideList(base.Select());
        }

        public void Update(Ride ride)
        {
            command.CommandText = $"UPDATE Rides SET rideId = {ride.Id}, " +
                $"rideRequestId = {ride.RideRequest.Id}, driverId = {ride.Driver.Id}, " +
                $"startTime = #{ride.StartTime}#, endTime = #{ride.EndTime}#, " +
                $"status = {(int)ride.Status}, price = {ride.Price} " +
                $"WHERE rideId = {ride.Id}";

            base.ExecuteNonQuery();
        }

        public void Insert(Ride ride)
        {
            command.CommandText = $"INSERT INTO Rides (rideId, rideRequestId, driverId, startTime, endTime, status, price)" +
                $"VALUES({ride.Id}, {ride.RideRequest.Id}, {ride.Driver.Id}, " +
                $"#{ride.StartTime}#, #{ride.EndTime}#, {(int)ride.Status}, {ride.Price})";
            base.ExecuteNonQuery();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Ride ride = entity as Ride;

            int rideId = int.Parse(reader["rideId"].ToString());
            int rideRequestId = int.Parse(reader["rideRequestId"].ToString());
            int driverId = int.Parse(reader["driverId"].ToString());
            DateTime startTime = (DateTime)reader["startTime"];
            DateTime endTime = (DateTime)reader["endTime"];
            RideStatus status = (RideStatus)int.Parse(reader["status"].ToString());
            double price = double.Parse(reader["price"].ToString());

            // יצירת אובייקטים - יש להשלים עם שליפות מהטבלאות המתאימות
            RideRequest rideRequest = new RideRequest(rideRequestId,
                new Customer("", "", 0, "", "", "", "", DateTime.Now, new Address(0, new City(0, ""), new Street(0, ""), "")),
                new Address(0, new City(0, ""), new Street(0, ""), ""),
                new Address(0, new City(0, ""), new Street(0, ""), ""),
                DateTime.Now, DateTime.Now, 0, RequestStatus.Pending);

            Driver driver = new Driver("", "", driverId, "", "", "", "", DateTime.Now,
                new Address(0, new City(0, ""), new Street(0, ""), ""), "",
                new Address(0, new City(0, ""), new Street(0, ""), ""),
                new Vehicle(0, "", 0, "", ""), false);

            return new Ride(rideId, rideRequest, driver, startTime, endTime, status, price);
        }

        protected override BaseEntity NewEntity()
        {
            return new Ride(0,
                new RideRequest(0,
                    new Customer("", "", 0, "", "", "", "", DateTime.Now, new Address(0, new City(0, ""), new Street(0, ""), "")),
                    new Address(0, new City(0, ""), new Street(0, ""), ""),
                    new Address(0, new City(0, ""), new Street(0, ""), ""),
                    DateTime.Now, DateTime.Now, 0, RequestStatus.Pending),
                new Driver("", "", 0, "", "", "", "", DateTime.Now,
                    new Address(0, new City(0, ""), new Street(0, ""), ""), "",
                    new Address(0, new City(0, ""), new Street(0, ""), ""),
                    new Vehicle(0, "", 0, "", ""), false),
                DateTime.Now, DateTime.Now, RideStatus.WaitingForDriver, 0.0);
        }
    }
}

