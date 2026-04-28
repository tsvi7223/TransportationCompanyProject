using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class ManagerDB : UserDB
    {

        private static ManagerDB instance;

        private ManagerDB() { }

        public static ManagerDB GetInstance()
        {
            if (instance == null)
                instance = new ManagerDB();
            return instance;
        }

        public void Delete(Manager manager)
        {
            command.CommandText = $"DELETE FROM Managers WHERE(Managers.driverId = {manager.Id})";
            base.ExecuteNonQuery();
            base.Delete(manager);
        }

        public ManagerList SelectAll()
        {
            command.CommandText = $"SELECT People.*, Users.*, Drivers.*," +
                $" People.PersonId FROM((People INNER JOIN Users ON People.PersonId = Users.UserId)" +
                $" INNER JOIN Drivers ON Users.UserId = Drivers.DriverId)";
            return new ManagerList(base.Select());
        }
        public Manager SelectById(int id)
        {
            command.CommandText = $"SELECT People.*, Users.*, Drivers.*," +
             $" People.PersonId FROM((People INNER JOIN Users ON People.PersonId = Users.UserId)" +
             $" INNER JOIN Drivers ON Users.UserId = Drivers.DriverId) WHERE(Managers.ManagerId = {id})";

            ManagerList manager = null;
            manager = new ManagerList(base.Select());
            try
            {
                return manager[0];
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message +"managersdb is null" );
            }
            return null;
        }

        public void Update(Manager manager)
        {
            command.CommandText = $"UPDATE Managers SET ManagerId =  {manager.Id} WHERE (ManagerId = {manager.Id})";

            base.ExecuteNonQuery();
            base.Update(manager);
        }

        public void Insert(Manager manager)
        {
            command.CommandText = $"INSERT INTO Managers (ManagerId) VALUES{5}";
            base.ExecuteNonQuery();
            base.Insert(manager);
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Manager manager = entity as Manager;

            manager.Id = int.Parse(reader["ManagerId"].ToString());
            base.CreateModel(manager);
            return manager; 
        }

        protected override BaseEntity NewEntity()
        {
            return new Manager();
        }
    }
}

