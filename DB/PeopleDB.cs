using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class PeopleDB:BaseDB
    {

        private static PeopleDB instance;

        private PeopleDB() { }

        public static PeopleDB GetInstance()
        {
            if (instance == null)
                instance = new PeopleDB();
            return instance;
        }

        public void Delete(Person person)
        {
            command.CommandText = $"DELETE FROM People WHERE(People.personId = {person.Id})";
            base.ExecuteNonQuery();
        }
        public PeopleList SelectAll()
        {
            command.CommandText = "SELECT * FROM People";
            return new PeopleList(base.Select());
        }
        public Person SelectById(int id)
        {
            PeopleList people = null;
            command.CommandText = $"SELECT * FROM People WHERE PersonId = {id}";
                people = new PeopleList(base.Select());
            try
            {
            return people[0];
            }
            catch(Exception e)
            {
                    System.Diagnostics.Debug.WriteLine("error: " + e.Message + "\nSQL: " + command.CommandText + "\nPeople was null");
                    // עדיף מאשר:
                    Console.WriteLine("error: " + e.Message);
               
            }
            return null;

        }
        public void Update(Person person)
        {
            command.CommandText = $"UPDATE people SET personId = {person.Id}, firstName = '{person.fName}', " +
                $"lastname = '{person.lName}', phoneNumber = '{person.phoneNumber}', " +
                $"emailAddress = '{person.emailAddress}', dateOfBirth = #{person.dateOfBirth}#, " +
                $"addressId = {person.address.Id} WHERE personID = {person.Id}";

            base.ExecuteNonQuery();
        }
        public void Insert(Person person)
        {
            command.CommandText = $"INSERT INTO people ( personId , firstName ,lastname, phoneNumber, emailAddress , dateOfBirth , addressId)" +
                $"VALUES({person.Id},'{person.fName}','{person.lName}','{person.phoneNumber}','{person.emailAddress}',#{person.dateOfBirth}#, {person.address.Id})";
            base.ExecuteNonQuery();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {

            Person person = entity as Person;
            //  המרות (Casting) בטוחות יותר למקרה של ערכי NULL או סוגים שונים
            person.Id=(int.Parse(reader["personID"].ToString()));
            person.fName = reader["firstname"].ToString();
            person.lName = reader["lastname"].ToString();
            person.phoneNumber = reader["phoneNumber"].ToString();
            person.emailAddress = reader["emailAddress"].ToString();
            person.dateOfBirth = (DateTime)reader["dateOfBirth"];

            int addressId = int.Parse(reader["addressId"].ToString());
            person.address = AddressDB.GetInstance().SelectById(addressId);

            

            return person as BaseEntity;
        }

        protected override BaseEntity NewEntity()
        {
            return new Person();
        }

    }
}
