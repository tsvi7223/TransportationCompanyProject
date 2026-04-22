using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class UserDB : BaseDB
    {

        private static UserDB instance;

        private UserDB() { }

        public static UserDB GetInstance()
        {
            if (instance == null)
                instance = new UserDB();
            return instance;
        }

        public void Delete(User user)
        {
            command.CommandText = $"DELETE FROM Users WHERE(Users.userId = {user.Id})";
            base.ExecuteNonQuery();
        }

        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM Users";
            return new UserList(base.Select());
        }
        public User SelectById(int ID)
        {
            command.CommandText = $"SELECT * FROM Users WHERE UserId={ID}";
            UserList users = null;
            try
            {
                users = new UserList(base.Select());
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
            }
            return users[0];

        }


        public UserList SelectByUserName(String name)
        {
            command.CommandText = $"SELECT * FROM Users  WHERE UserName = '{name}'";
            return new UserList(base.Select());
        }

        public void Update(User user)
        {
            command.CommandText = $"UPDATE Users SET userId = {user.Id}, " +
                $"firstName = '{user.fName}', lastname = '{user.lName}', " +
                $"phoneNumber = '{user.phoneNumber}', emailAddress = '{user.emailAddress}', " +
                $"dateOfBirth = #{user.dateOfBirth}#, addressId = {user.address.Id}, " +
                $"userName = '{user.UserName}', userPassword = '{user.UserPassword}', ";
                //$"userType = {(int)user.Type} WHERE userId = {user.Id}
                

            base.ExecuteNonQuery();
        }

        public void Insert(User user)
        {
            command.CommandText = $"INSERT INTO Users (userId, firstName, lastname, phoneNumber, emailAddress, dateOfBirth, addressId, userName, userPassword, userType)" +
                $"VALUES({user.Id}, '{user.fName}', '{user.lName}', '{user.phoneNumber}', '{user.emailAddress}', " +
                $"#{user.dateOfBirth}#, {user.address.Id}, '{user.UserName}', '{user.UserPassword}')";
            base.ExecuteNonQuery();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            // הערה: User הוא מחלקה מופשטת, לכן נצטרך ליצור מופע של Customer, Driver או Manager
            // בהתאם ל-userType
            User user = entity as User;
            user.Id = int.Parse(reader["userId"].ToString());
            user.UserName = reader["userName"].ToString();
            user.UserPassword = reader["userPassword"].ToString();

            Person person1 = user as Person;
            Person person = PeopleDB.GetInstance().SelectById(user.Id);
            person1.Copy(person);

            //user.fName = person.fName;
            //user.lName = person.lName;
            //user.phoneNumber = person.phoneNumber;
            //user.emailAddress = person.emailAddress;
            //user.dateOfBirth = person.dateOfBirth;
            //user.address = person.address;


            //UserType userType = (UserType)int.Parse(reader["userType"].ToString());

            // יצירת כתובת - יש להשלים עם שליפה מטבלת Address
           // Address address = new Address(addressId, new City(0, ""), new Street(0, ""), "");

            // יצירת המשתמש המתאים בהתאם לסוג
            //User user = null;
            //switch (userType)
            //{
            //    case UserType.Customer:
            //        user = new Customer(userPassword, userName, userId, lName, fName, phoneNumber, emailAddress, dateOfBirth, address);
            //        break;
            //    case UserType.Manager:
            //        user = new Manager(userPassword, userName, userId, lName, fName, phoneNumber, emailAddress, dateOfBirth, address);
            //        break;
            //    case UserType.Driver:
            //        // לנהג יש פרמטרים נוספים, נוסיף ערכי ברירת מחדל
            //        user = new Driver(userPassword, userName, userId, lName, fName, phoneNumber, emailAddress, dateOfBirth, address, "", address, null, false);
            //        break;
            //}

            return user as BaseEntity;
        }



        protected override BaseEntity NewEntity()
        {
            // User הוא מופשט, נחזיר Customer כברירת מחדל
            //return new Customer("", "", 0, "", "", "", "", DateTime.Now, new Address(0, new City(0, ""), new Street(0, ""), ""));
            return new User();
        }
    }
}

