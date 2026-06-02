using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    [DataContract]
    public class StreetDB : BaseDB
    {

        [DataMember]
        private static StreetDB instance;

        private StreetDB() { }

        [OperationContract]
        public static StreetDB GetInstance()
        {
            if (instance == null)
                instance = new StreetDB();
            return instance;
        }

        [OperationContract]
        public void Delete(Street street)
        {
            command.CommandText = $"DELETE FROM Streets WHERE(Street.streetId = {street.Id})";
            base.ExecuteNonQuery();
        }

        [OperationContract]
        public StreetList SelectAll()
        {
            command.CommandText = "SELECT * FROM Streets";
            return new StreetList(base.Select());
        }

        [OperationContract]
        public void Update(Street street)
        {
            command.CommandText = $"UPDATE Streets SET streetId = {street.Id}, " +
                $"streetName = '{street.StreetName}' WHERE streetId = {street.Id}";

            base.ExecuteNonQuery();
        }

        [OperationContract]
        public void Insert(Street street)
        {
            command.CommandText = $"INSERT INTO Streets (streetId, streetName)" +
                $"VALUES({street.Id}, '{street.StreetName}')";
            base.ExecuteNonQuery();
        }

        [OperationContract]
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Street street = entity as Street;

            street.Id = int.Parse(reader["streetId"].ToString());
            street.StreetName = reader["streetName"].ToString();

            return street;
        }

        [OperationContract]
        protected override BaseEntity NewEntity()
        {
            return new Street();
        }

        [OperationContract]
        internal Street SelectById(int Id)
        {
            command.CommandText = $"SELECT * FROM Streets WHERE streetId = {Id}";
            StreetList streets = new StreetList(base.Select());
            try
            {
                return streets[0];
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message + " this id is not used by any Street");
            }
            return null;
        }
    }
}

//using System;
 //using System.Collections.Generic;
 //using System.Linq;
 //using System.Text;
 //using System.Threading.Tasks;
 //using TransportationCompanyProject.Model;

//namespace TransportationCompanyProject.DB
//{
//    public class StreetDB : BaseDB
//    {

//        private static StreetDB instance;

//        private StreetDB() { }

//        public static StreetDB GetInstance()
//        {
//            if (instance == null)
//                instance = new StreetDB();
//            return instance;
//        }

//        public void Delete(Street street)
//        {
//            command.CommandText = $"DELETE FROM Street WHERE(Street.streetId = {street.Id})";
//            base.ExecuteNonQuery();
//        }

//        public StreetList SelectAll()
//        {
//            command.CommandText = "SELECT * FROM Street";
//            return new StreetList(base.Select());
//        }

//        public void Update(Street street)
//        {
//            command.CommandText = $"UPDATE Street SET streetId = {street.Id}, " +
//                $"streetName = '{street.StreetName}' WHERE streetId = {street.Id}";

//            base.ExecuteNonQuery();
//        }

//        public void Insert(Street street)
//        {
//            command.CommandText = $"INSERT INTO Street (streetId, streetName)" +
//                $"VALUES({street.Id}, '{street.StreetName}')";
//            base.ExecuteNonQuery();
//        }

//        protected override BaseEntity CreateModel(BaseEntity entity)
//        {
//            Street street = entity as Street;

//            street.Id = int.Parse(reader["streetId"].ToString());
//            street.StreetName = reader["streetName"].ToString();

//            return street;
//        }

//        protected override BaseEntity NewEntity()
//        {
//            return new Street();
//        }

//        internal Street SelectById(int Id)
//        {
//            command.CommandText = $"SELECT * FROM Street WHERE streetId = {Id}";
//            StreetList streets = new StreetList(base.Select());
//            try
//            {
//                return streets[0];
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("error: " + e.Message + " this id is not used by any Street");
//            }
//            return null;
//        }
//    }
//}

