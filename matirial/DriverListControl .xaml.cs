using System.Windows.Controls;

namespace TransportationCompanyProject.GUI
{
    /// <summary>
    /// Interaction logic for DriverListPage.xaml
    /// </summary>
    public partial class DriverListControl : UserControl
    {
        public DriverListControl()
        {
            InitializeComponent();
            listView.ItemsSource = DB.DriverDB.GetInstance().SelectAll();
        }
    }
}
