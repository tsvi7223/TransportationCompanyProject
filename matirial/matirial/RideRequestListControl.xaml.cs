using System.Windows.Controls;

namespace TransportationCompanyProject.GUI
{
    /// <summary>
    /// Interaction logic for RideRequestListPage.xaml
    /// </summary>
    public partial class RideRequestListControl : UserControl
    {
        public RideRequestListControl()
        {
            InitializeComponent();
            listView.ItemsSource = DB.RideRequestDB.GetInstance().SelectAll();
        }
    }
}
