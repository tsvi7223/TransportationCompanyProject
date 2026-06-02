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
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.GUI.NewFolder1
{
    /// <summary>
    /// Interaction logic for Customer_home_page.xaml
    /// </summary>
    public partial class Customer_home_page : Page
    {
        public User user = new User();

        public Customer_home_page(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void NewRide_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelRide_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PersonalArea_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
