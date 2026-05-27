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

namespace TransportationCompanyProject.GUI
{
    /// <summary>
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {

        //String typeOfUser;

        //Boolean isDriver() { return (typeOfUser == "Driver") ; }
        //Boolean isCustomer() { return (typeOfUser == "Customer"); }
        public SignUpPage()
        {
            
            InitializeComponent();
            //this.typeOfUser = typeOfUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
