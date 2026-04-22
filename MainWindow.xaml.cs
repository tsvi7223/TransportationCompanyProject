using System.Windows;
using TransportationCompanyProject.DB;
using TransportationCompanyProject.GUI;
using TransportationCompanyProject.Util;

namespace TransportationCompanyProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VehicleList view;

        public MainWindow()
        {

            InitializeComponent();
            this.mainframe.Navigate(new LoginPage());
            //this.mainframe.Navigate(new VehicleListControl());
            //VehicleSeeder.Seed(5);
            //MainFrame.Navigate(new LoginPage());
            //MainFrame.Navigate(new ManagerHomePage());

            //view = DB.VehicleDB.GetInstance().SelectAll();
            //listView.ItemsSource = view;
        }

      
    }
}

