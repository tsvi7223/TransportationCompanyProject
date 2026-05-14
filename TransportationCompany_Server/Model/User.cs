using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using System.ComponentModel;
using TransportationCompanyProject.DB;

namespace TransportationCompanyProject.Model
{

    public class User : Person, INotifyPropertyChanged
    {
        private string userPassword = string.Empty;
        public string UserPassword
        {
            get => userPassword;
            set
            {
                userPassword = value;
                OnPropertyChanged(nameof(UserPassword));
            }
        }

        private string userName = string.Empty;
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

       // public UserType Type { get; set; } = UserType.Customer;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public User() { }

        public User(string userPassword, string userName, int Id,
            string lName, string fName, string phoneNumber, string emailAddress,
            DateTime dateOfBirth, Address address)
            : base(Id, lName, fName, phoneNumber, emailAddress, dateOfBirth, address)
        {
            UserPassword = userPassword;
            UserName = userName;

        }

        //public void Copy(User other)
        //{
        //    this.UserPassword = other.userPassword;
        //    this.UserName = other.userName;

        //    PeopleDB peopleDB = PeopleDB.GetInstance();
        //    Person person = peopleDB.SelectById(other.Id);
        //    base.Copy(person);
        //}
    }
    //public class User : Person
    //{
    //    public string UserPassword { get; set; } = string.Empty;
    //    public string UserName { get; set; } = String.Empty;
    //    public UserType Type { get; set; } = UserType.Customer;

    //    public User(string userPassword, string UserName, int Id,
    //        string lName, string fName, string phoneNumber, string emailAddress,
    //        DateTime dateOfBirth, Address address, UserType type) 
    //        : base(Id, lName, fName, phoneNumber, emailAddress, dateOfBirth, address)
    //    {
    //        this.UserPassword = userPassword;
    //        this.UserName = UserName;
    //        this.Type = type;
    //    }

    //    public User()
    //    {
    //        this.UserName = String.Empty;
    //        this.UserPassword = String.Empty;
    //        this.Type= UserType.Customer;
    //    }
    //}


}
