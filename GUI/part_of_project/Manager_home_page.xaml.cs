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
    /// Interaction logic for Manager_home_page.xaml
    /// </summary>
    public partial class Manager_home_page : Page
    {
        public User user = new User();
        public Manager_home_page(User user)
        {
            InitializeComponent();
            this.user = user;
        }


        private void ApproveDriver_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RejectDriver_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AssignDriver_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
