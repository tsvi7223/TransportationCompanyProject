using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TransportationCompany_Server;
using TransportationCompanyProject.DB;
using TransportationCompanyProject.GUI.NewFolder1;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.GUI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public User user = new User();
        Transportation_service TranService = new Transportation_service();
       public LoginPage()
        {
            InitializeComponent();
            this.DataContext = user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SignUpPage());
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{

        //}

  

        private void Manager_back_door_Click(object sender, RoutedEventArgs e)
        {
            user.UserPassword = "Cd";
            user.UserName = "Bc";
            

        }

        private void Driver_back_door_Click(object sender, RoutedEventArgs e)
        {
            PassTbox.Text = "Bc";
            UserNameTbox.Text = "Ab";
           

        }

        private void Customer_back_door_Click(object sender, RoutedEventArgs e)
        {
            PassTbox.Text = "Hi";
            UserNameTbox.Text = "Gi";
        }

        private void login(object sender, RoutedEventArgs e)
        {
           // TranService.Delete(new City());

 //First find the user in our database
            //DB.UserList users = UserDB.GetInstance().SelectByUserProprty(UserNameTbox.Text,PassTbox.Text);
            UserList users = TranService.SelectByUserProprty(UserNameTbox.Text, PassTbox.Text);
            if (users.First().UserName == UserNameTbox.Text && users.First().UserPassword == PassTbox.Text)
            {
                if(Customer cust = CustomerDB.GetInstance().SelectById(user.Id) == null)
                        if(Driver Driver = DriverDB.GetInstance().SelectById(user.Id))
                Manager Manager = ManagerDB.GetInstance().SelectById(user.Id);
                this.user = users.First();
                NavigationService nav = NavigationService.GetNavigationService(this);

                switch (user.GetType())
                {
                    case UserType.Manager:
                        nav.Navigate(new Manager_home_page(user));
                        break;

                    case UserType.Driver:
                        nav.Navigate(new Driver_home_page(user));
                        break;

                    case UserType.Customer:
                        nav.Navigate(new Customer_home_page(user));
                        break;

                    default:
                        MessageBox.Show("סוג משתמש לא מוכר");
                        break;
                }
                //לשלוח משתמש דרך בנאי
               
            }
            else
            {
                MessageBox.Show("אחד או יותר מהנתונים שהכנסת שגויים אנא נסה שנית ", "", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
