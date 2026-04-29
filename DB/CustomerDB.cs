using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class CustomerDB : UserDB
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
            base.Delete(customer);
        }

        public CustomerList SelectAll()
        {
            command.CommandText = $"SELECT People.*, Users.*, Customers.*," +
                $" People.PersonId FROM ((People INNER JOIN Users ON People.PersonId = Users.UserId) " +
                $"INNER JOIN Customers ON Users.UserId = Customers.CustomerId)";
            return new CustomerList(base.Select());
        }
        public Customer SelectById(int id)
        {
            command.CommandText = $"SELECT People.*, Users.*, Customers.*," +
                $" People.PersonId FROM ((People INNER JOIN Users ON People.PersonId = Users.UserId) " +
                $"INNER JOIN Customers ON Users.UserId = Customers.CustomerId) WHERE(Customers.CustomerID = {id})";

            CustomerList  customer = new CustomerList(base.Select());
            try
            {
                return customer[0];
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message + "customersdb is null");
            }
            return null;
        }

        public void Update(Customer customer)
        {
            command.CommandText = $"UPDATE Customers SET CustomerID = {customer.Id} WHERE (CustomerID = {customer.Id})";
           
            base.ExecuteNonQuery();
            base.Update(customer);
        }

        public void Insert(Customer customer)

        {
            command.CommandText = $"INSERT INTO Customers (CustomerId) VALUES{5}";
            base.ExecuteNonQuery();
            base.Insert(customer);
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Customer customer = entity as Customer;

            customer.Id = int.Parse(reader["customerid"].ToString());
            base.CreateModel(customer);
            return customer;
        }

        protected override BaseEntity NewEntity()
        {
            return new Customer();
        }
    }
}

