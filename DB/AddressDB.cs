using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class AddressDB : BaseDB
    {

        private static AddressDB instance;

        private AddressDB() { }

        public static AddressDB GetInstance()
        {
            if (instance == null)
                instance = new AddressDB();
            return instance;
        }

        public void Delete(Address address)
        {
            command.CommandText = $"DELETE FROM Address WHERE(Address.addressId = {address.Id})";
            base.ExecuteNonQuery();
        }

        public AddressList SelectAll()
        {
            command.CommandText = "SELECT * FROM Address";
            return new AddressList(base.Select());
        }
        public Address SelectById(int id)
        {
            command.CommandText = $"SELECT * FROM Address WHERE AddressID = {id}";
            AddressList addresses = new AddressList(base.Select());
            return addresses[0];
        }


        public void Update(Address address)
        {
            command.CommandText = $"UPDATE Address SET addressId = {address.Id}, " +
                $"cityId = {address.City.Id}, streetId = {address.Street.Id}, " +
                $"buildingNumber = '{address.BuildingNumber}' WHERE addressId = {address.Id}";

            base.ExecuteNonQuery();
        }

        public void Insert(Address address)
        {
            command.CommandText = $"INSERT INTO Address (addressId, cityId, streetId, buildingNumber)" +
                $"VALUES({address.Id}, {address.City.Id}, {address.Street.Id}, '{address.BuildingNumber}')";
            base.ExecuteNonQuery();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Address address = entity as Address;
            
            // המרות (Casting) בטוחות יותר למקרה של ערכי NULL או סוגים שונים
            int addressId = int.Parse(reader["addressId"].ToString());
            int cityId = int.Parse(reader["cityId"].ToString());
            int streetId = int.Parse(reader["streetId"].ToString());
            string buildingNumber = reader["buildingNumber"].ToString();

            // יצירת אובייקטים של City ו-Street
            // הערה: ייתכן שתצטרך לטעון את שמות העיר והרחוב מטבלאות נפרדות
            City city = new City(cityId, ""); // יש להשלים עם שאילתת JOIN או שליפה נפרדת
            Street street = new Street(streetId, ""); // יש להשלים עם שאילתת JOIN או שליפה נפרדת

            return new Address(addressId, city, street, buildingNumber);
        }

        protected override BaseEntity NewEntity()
        {
            // יצירת אובייקט ריק - יש להשלים עם ערכי ברירת מחדל מתאימים
            return new Address(0, new City(0, ""), new Street(0, ""), "");
        }
    }
}

