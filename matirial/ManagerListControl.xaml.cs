using System.Windows.Controls;

namespace TransportationCompanyProject.GUI
{
    /// <summary>
    /// Interaction logic for ManagerListPage.xaml
    /// </summary>
    public partial class ManagerListControl : UserControl
    {
        public ManagerListControl()
        {
            InitializeComponent();
            listView.ItemsSource = DB.ManagerDB.GetInstance().SelectAll();
        }
    }
}
