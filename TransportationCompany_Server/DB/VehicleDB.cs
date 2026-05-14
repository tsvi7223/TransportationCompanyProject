using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class VehicleDB : BaseDB
    {

        private static VehicleDB instance;

        private VehicleDB() { }

        public static VehicleDB GetInstance()
        {
            if (instance == null)
                instance = new VehicleDB();
            return instance;
        }

        public void Delete(Vehicle vehicle)
        {
            command.CommandText = $"DELETE FROM Vehicles WHERE(VehicleId = {vehicle.Id})";
            base.ExecuteNonQuery();
        }

        public VehicleList SelectAll()
        {
            command.CommandText = "SELECT * FROM Vehicles";
            return new VehicleList(base.Select());
        }
        public Vehicle SelectById(int id)
        {
            
           
                VehicleList vehicles = null;
                command.CommandText = $"SELECT * FROM Vehicles WHERE VehicleId = {id}";
                try
                {
                    vehicles = new VehicleList(base.Select());
                }
                catch (Exception e)
                {
                    Console.WriteLine("error: " + e.Message);
                }
                return vehicles[0];

           
        }

        public void Update(Vehicle vehicle)
        {
            command.CommandText = $"UPDATE Vehicles SET VehicleId = {vehicle.Id}, " +
                $"vehicleType = '{vehicle.VehicleType}', capacity = {vehicle.Capacity}, " +
                $"licensePlate = '{vehicle.LicensePlate}', status = '{vehicle.Status}' " +
                $"WHERE vehicleId = {vehicle.Id}";

            base.ExecuteNonQuery();
        }

        public void Insert(Vehicle vehicle)
        {
            command.CommandText = $"INSERT INTO Vehicles (VehicleId, vehicleType, capacity, licensePlate, status) " +
                $"VALUES ({vehicle.Id}, '{vehicle.VehicleType}', {vehicle.Capacity}, '{vehicle.LicensePlate}', '{vehicle.Status}')";
            base.ExecuteNonQuery();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Vehicle vehicle = entity as Vehicle;
            
            int vehicleId = int.Parse(reader["VehicleId"].ToString());
            string vehicleType = reader["vehicleType"].ToString();
            int capacity = int.Parse(reader["capacity"].ToString());
            string licensePlate = reader["licensePlate"].ToString();
            string status = reader["status"].ToString();

            return new Vehicle(vehicleId, vehicleType, capacity, licensePlate, status);
        }

        protected override BaseEntity NewEntity()
        {
            return new Vehicle(0, "", 0, "", "");
        }
    }
}

