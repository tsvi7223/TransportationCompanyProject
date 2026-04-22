using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class ManagerDB : BaseDB
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
            command.CommandText = $"DELETE FROM Users WHERE(Users.userId = {manager.Id})";
            base.ExecuteNonQuery();
        }

        public ManagerList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Users WHERE userType = {(int)UserType.Manager}";
            return new ManagerList(base.Select());
        }

        public void Update(Manager manager)
        {
            command.CommandText = $"UPDATE Users SET userId = {manager.Id}, " +
                $"firstName = '{manager.fName}', lastname = '{manager.lName}', " +
                $"phoneNumber = '{manager.phoneNumber}', emailAddress = '{manager.emailAddress}', " +
                $"dateOfBirth = #{manager.dateOfBirth}#, addressId = {manager.address.Id}, " +
                $"userName = '{manager.UserName}', userPassword = '{manager.UserPassword}', " +
                $"userType = {(int)UserType.Manager} WHERE userId = {manager.Id}";

            base.ExecuteNonQuery();
        }

        public void Insert(Manager manager)
        {
            command.CommandText = $"INSERT INTO Users (userId, firstName, lastname, phoneNumber, emailAddress, dateOfBirth, addressId, userName, userPassword, userType)" +
                $"VALUES({manager.Id}, '{manager.fName}', '{manager.lName}', '{manager.phoneNumber}', '{manager.emailAddress}', " +
                $"#{manager.dateOfBirth}#, {manager.address.Id}, '{manager.UserName}', '{manager.UserPassword}', {(int)UserType.Manager})";
            base.ExecuteNonQuery();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Manager manager = entity as Manager;

            int userId = int.Parse(reader["userId"].ToString());
            string fName = reader["firstName"].ToString();
            string lName = reader["lastname"].ToString();
            string phoneNumber = reader["phoneNumber"].ToString();
            string emailAddress = reader["emailAddress"].ToString();
            DateTime dateOfBirth = (DateTime)reader["dateOfBirth"];
            int addressId = int.Parse(reader["addressId"].ToString());
            string userName = reader["userName"].ToString();
            string userPassword = reader["userPassword"].ToString();

            // יצירת כתובת - יש להשלים עם שליפה מטבלת Address
            Address address = new Address(addressId, new City(0, ""), new Street(0, ""), "");

            return new Manager(userPassword, userName, userId, lName, fName, phoneNumber, emailAddress, dateOfBirth, address);
        }

        protected override BaseEntity NewEntity()
        {
            return new Manager("", "", 0, "", "", "", "", DateTime.Now, new Address(0, new City(0, ""), new Street(0, ""), ""));
        }
    }
}

