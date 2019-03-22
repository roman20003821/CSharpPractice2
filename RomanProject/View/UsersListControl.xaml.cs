using System.Windows.Controls;
using RomanProject.Tools.Navigation;
using RomanProject.ViewModel;

namespace RomanProject.View
{
    /// <summary>
    /// Interaction logic for UsersGridControl.xaml
    /// </summary>
    public partial class UsersListControl : UserControl,INavigatable
    {
        public UsersListControl()
        {
            InitializeComponent();
            DataContext = new UsersListViewModel();
        }
    }
}
