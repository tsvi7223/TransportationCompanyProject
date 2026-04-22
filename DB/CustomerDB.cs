using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class CustomerDB : BaseDB
    {

        private static CustomerDB instance;

        private CustomerDB() { }

        public static CustomerDB GetInstance()
        {
            if (instance == null)
                instance = new CustomerDB();
            return instance;
        }

        public void Delete(Customer customer)
        {
            command.CommandText = $"DELETE FROM Users WHERE(Users.userId = {customer.Id})";
            base.ExecuteNonQuery();
        }

        public CustomerList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Users WHERE userType = {(int)UserType.Customer}";
            return new CustomerList(base.Select());
        }

        public void Update(Customer customer)
        {
            command.CommandText = $"UPDATE Users SET userId = {customer.Id}, " +
                $"firstName = '{customer.fName}', lastname = '{customer.lName}', " +
                $"phoneNumber = '{customer.phoneNumber}', emailAddress = '{customer.emailAddress}', " +
                $"dateOfBirth = #{customer.dateOfBirth}#, addressId = {customer.address.Id}, " +
                $"userName = '{customer.UserName}', userPassword = '{customer.UserPassword}', " +
                $"userType = {(int)UserType.Customer} WHERE userId = {customer.Id}";

            base.ExecuteNonQuery();
        }

        public void Insert(Customer customer)
        {
            command.CommandText = $"INSERT INTO Users (userId, firstName, lastname, phoneNumber, emailAddress, dateOfBirth, addressId, userName, userPassword, userType)" +
                $"VALUES({customer.Id}, '{customer.fName}', '{customer.lName}', '{customer.phoneNumber}', '{customer.emailAddress}', " +
                $"#{customer.dateOfBirth}#, {customer.address.Id}, '{customer.UserName}', '{customer.UserPassword}', {(int)UserType.Customer})";
            base.ExecuteNonQuery();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Customer customer = entity as Customer;

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

            return new Customer(userPassword, userName, userId, lName, fName, phoneNumber, emailAddress, dateOfBirth, address);
        }

        protected override BaseEntity NewEntity()
        {
            return new Customer("", "", 0, "", "", "", "", DateTime.Now, new Address(0, new City(0, ""), new Street(0, ""), ""));
        }
    }
}

