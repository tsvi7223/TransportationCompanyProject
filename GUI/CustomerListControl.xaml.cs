using System.Windows.Controls;

namespace TransportationCompanyProject.GUI
{
    /// <summary>
    /// Interaction logic for CustomerListPage.xaml
    /// </summary>
    public partial class CustomerListControl : UserControl
    {
        public CustomerListControl()
        {
            InitializeComponent();
            listView.ItemsSource = DB.CustomerDB.GetInstance().SelectAll();
        }
    }
}
