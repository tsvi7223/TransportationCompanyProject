using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public class UserDB : PeopleDB
    {

        private static UserDB instance;

        protected UserDB() { }

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
            base.Delete(user); // מחיקת האדם מהטבלה People
        }

        public UserList SelectAll()
        {
            //command.CommandText = "SELECT * FROM Users";
                command.CommandText = "SELECT Users.*, People.*" +
                "FROM  (Users INNER JOIN People ON Users.UserId = People.PersonId)";
                return new UserList(base.Select());
        }
        public User SelectById(int ID)
        {
            //command.CommandText = $"SELECT * FROM Users WHERE UserId={ID}";
            command.CommandText = $"SELECT Users.*, People.* " +
                $"FROM   (Users INNER JOIN People ON Users.UserId = People.PersonId)" +
                $"WHERE  (Users.UserId = '{ID}')"; ;
            UserList users = null;
            users = new UserList(base.Select());
            try
            {
                return users[0];
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("error: " + e.Message + "\nSQL: " + command.CommandText + "\nUsers was null");
            }
            return null;

        }


        public UserList SelectByUserProprty(string name,string password)
        {
            //command.CommandText = $"SELECT * FROM Users  WHERE UserName = '{name}'";
            command.CommandText = $"SELECT Users.*, People.* " +
                $"FROM (Users INNER JOIN People ON Users.UserId = People.PersonId)" +
                $"WHERE (Users.UserName = '{name}')";

            command.CommandText = $"SELECT People.*, Users.*" +
                $" FROM (People INNER JOIN Users ON People.PersonId = Users.UserId)" +
                $" WHERE (Users.UserPassword = {password}) AND(Users.UserName = {name})";
            return new UserList(base.Select());
        }

        public void Update(User user)
        {
            //TODO: עדכון צריך להתבצע בשתי טבלאות - גם ב-Users וגם ב-People, כרגע מתעדכן רק ב-Users
            command.CommandText = $"UPDATE Users SET userId = {user.Id}, " +
                $"userName = '{user.UserName}', userPassword = '{user.UserPassword}', ";
            base.ExecuteNonQuery();
            base.Update(user);  
        }

        public void Insert(User user)
        {
            //TODO: הוספה צריכה להתבצע בשתי טבלאות - גם ב-Users וגם ב-People, כרגע מתבצעת רק ב-Users
            command.CommandText = $"INSERT INTO Users (userId ,userName, userPassword)" +
                $"VALUES({user.Id}, '{user.UserName}', '{user.UserPassword}') WHERE (userId= {user.Id})";
            base.ExecuteNonQuery();
            base.Insert(user);
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
          
            User user = entity as User;

            user.Id = int.Parse(reader["userId"].ToString());
            user.UserName = reader["userName"].ToString();
            user.UserPassword = reader["userPassword"].ToString();

            base.CreateModel(user); // מילוי שדות Person דרך BaseDB
            return user;
            //Person person1 = user as Person;
            //Person person = PeopleDB.GetInstance().SelectById(user.Id);
            //person1.Copy(person);

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


        }



        protected override BaseEntity NewEntity()
        {
            // User הוא מופשט, נחזיר Customer כברירת מחדל
            return new User();
        }
    }
}

