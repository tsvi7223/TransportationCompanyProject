using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.DB;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.Util
{
  
        public static class VehicleSeeder
        {
            public static void Seed(int amount)
            {
                Random rnd = new Random();

                string[] vehicleTypes = { "Bus", "Car", "Truck", "Van", "Motorcycle" };
                string[] statuses = { "Available", "InUse", "Maintenance" };

                for (int i = 0; i < amount; i++)
                {
                    Vehicle v = new Vehicle(
                        Id: rnd.Next(1000, 9999),
                        vehicleType: vehicleTypes[rnd.Next(vehicleTypes.Length)],
                        capacity: rnd.Next(2, 60),
                        licensePlate: GeneratePlate(rnd),
                        status: statuses[rnd.Next(statuses.Length)]
                    );

                    VehicleDB.GetInstance().Insert(v);
                }
            }

            private static string GeneratePlate(Random rnd)
            {
                return $"{rnd.Next(10, 99)}-{rnd.Next(100, 999)}-{rnd.Next(10, 99)}";
            }
        }
    
}
