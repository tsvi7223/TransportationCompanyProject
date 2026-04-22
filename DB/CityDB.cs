using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class CityDB : BaseDB
    {

        private static CityDB instance;

        private CityDB() { }

        public static CityDB GetInstance()
        {
            if (instance == null)
                instance = new CityDB();
            return instance;
        }

        public void Delete(City city)
        {
            command.CommandText = $"DELETE FROM City WHERE(City.cityId = {city.Id})";
            base.ExecuteNonQuery();
        }

        public CityList SelectAll()
        {
            command.CommandText = "SELECT * FROM City";
            return new CityList(base.Select());
        }

        public void Update(City city)
        {
            command.CommandText = $"UPDATE City SET cityId = {city.Id}, " +
                $"cityName = '{city.CityName}' WHERE cityId = {city.Id}";

            base.ExecuteNonQuery();
        }

        public void Insert(City city)
        {
            command.CommandText = $"INSERT INTO City (cityId, cityName)" +
                $"VALUES({city.Id}, '{city.CityName}')";
            base.ExecuteNonQuery();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            City city = entity as City;
            
            city.Id = int.Parse(reader["cityId"].ToString());
            city.CityName = reader["cityName"].ToString();

            return city as BaseEntity;
        }

        protected override BaseEntity NewEntity()
        {
            return new City(0, "");
        }
    }
}

