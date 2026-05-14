using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class RideRequestDB : BaseDB
    {

        private static RideRequestDB instance;

        private RideRequestDB() { }

        public static RideRequestDB GetInstance()
        {
            if (instance == null)
                instance = new RideRequestDB();
            return instance;
        }

        public void Delete(RideRequest rideRequest)
        {
            command.CommandText = $"DELETE FROM RideRequests WHERE(RideRequests.rideRequestId = {rideRequest.Id})";
            base.ExecuteNonQuery();
        }

        public RideRequestList SelectAll()
        {
            command.CommandText = "SELECT * FROM RideRequests";
            return new RideRequestList(base.Select());
        }

        public void Update(RideRequest rideRequest)
        {
            command.CommandText = $"UPDATE RideRequests SET rideRequestId = {rideRequest.Id}, " +
                $"customerId = {rideRequest.Customer.Id}, pickupAddressId = {rideRequest.PickupAddress.Id}, " +
                $"destinationAddressId = {rideRequest.DestinationAddress.Id}, " +
                $"requestTime = #{rideRequest.RequestTime}#, scheduledTime = #{rideRequest.ScheduledTime}#, " +
                $"numberOfPassengers = {rideRequest.NumberOfPassengers}, status = {(int)rideRequest.Status} " +
                $"WHERE rideRequestId = {rideRequest.Id}";

            base.ExecuteNonQuery();
        }

        public void Insert(RideRequest rideRequest)
        {
            command.CommandText = $"INSERT INTO RideRequests (rideRequestId, customerId, pickupAddressId, destinationAddressId, requestTime, scheduledTime, numberOfPassengers, status)" +
                $"VALUES({rideRequest.Id}, {rideRequest.Customer.Id}, {rideRequest.PickupAddress.Id}, {rideRequest.DestinationAddress.Id}, " +
                $"#{rideRequest.RequestTime}#, #{rideRequest.ScheduledTime}#, {rideRequest.NumberOfPassengers}, {(int)rideRequest.Status})";
            base.ExecuteNonQuery();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            RideRequest rideRequest = entity as RideRequest;

            int rideRequestId = int.Parse(reader["rideRequestId"].ToString());
            int customerId = int.Parse(reader["customerId"].ToString());
            int pickupAddressId = int.Parse(reader["pickupAddressId"].ToString());
            int destinationAddressId = int.Parse(reader["destinationAddressId"].ToString());
            DateTime requestTime = (DateTime)reader["requestTime"];
            DateTime scheduledTime = (DateTime)reader["scheduledTime"];
            int numberOfPassengers = int.Parse(reader["numberOfPassengers"].ToString());
            RequestStatus status = (RequestStatus)int.Parse(reader["status"].ToString());

            // יצירת אובייקטים - יש להשלים עם שליפות מהטבלאות המתאימות
            Customer customer = new Customer("", "", customerId, "", "", "", "", DateTime.Now, 
                new Address(0, new City(0, ""), new Street(0, ""), ""));
            Address pickupAddress = new Address(pickupAddressId, new City(0, ""), new Street(0, ""), "");
            Address destinationAddress = new Address(destinationAddressId, new City(0, ""), new Street(0, ""), "");

            return new RideRequest(rideRequestId, customer, pickupAddress, destinationAddress, 
                requestTime, scheduledTime, numberOfPassengers, status);
        }

        protected override BaseEntity NewEntity()
        {
            return new RideRequest(0, 
                new Customer("", "", 0, "", "", "", "", DateTime.Now, new Address(0, new City(0, ""), new Street(0, ""), "")),
                new Address(0, new City(0, ""), new Street(0, ""), ""),
                new Address(0, new City(0, ""), new Street(0, ""), ""),
                DateTime.Now, DateTime.Now, 0, RequestStatus.Pending);
        }
    }
}

