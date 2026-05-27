using System.Windows.Controls;

namespace TransportationCompanyProject.GUI
{
    /// <summary>
    /// Interaction logic for RideListPage.xaml
    /// </summary>
    public partial class RideListControl : UserControl
    {
        public RideListControl()
        {
            InitializeComponent();
            listView.ItemsSource = DB.RideDB.GetInstance().SelectAll();
        }
    }
}
