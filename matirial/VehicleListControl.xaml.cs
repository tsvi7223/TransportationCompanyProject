using System.Windows.Controls;

namespace TransportationCompanyProject.GUI
{
    /// <summary>
    /// Interaction logic for VehicleListPage.xaml
    /// </summary>
    public partial class VehicleListControl : UserControl
    {
        public VehicleListControl()
        {
            InitializeComponent();
            listView.ItemsSource = DB.VehicleDB.GetInstance().SelectAll();

        }
    }
}
