using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TransportationCompanyProject.DB;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.GUI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public User user = new User();
       public LoginPage()
        {
            InitializeComponent();
            this.DataContext = user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SignUpPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

  

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
            //First find the user in our database
            DB.UserList users = UserDB.GetInstance().SelectByUserProprty(UserNameTbox.Text,PassTbox.Text);
            if (users.First().UserName == UserNameTbox.Text && users.First().UserPassword == PassTbox.Text)
            {
                this.user = users.First();
                NavigationService nav = NavigationService.GetNavigationService(this);
                //לשלוח משתמש דרך בנאי
                nav.Navigate(new ManagerHomePage(this.user));
            }
            else
            {
                MessageBox.Show("אחד או יותר מהנתונים שהכנסת שגויים אנא נסה שנית ", "", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
