using System.Windows.Controls;
using RomanProject.ViewModel;

namespace RomanProject.View
{
    /// <summary>
    /// Interaction logic for PersonInfoInput.xaml
    /// </summary>
    public partial class PersonInfoInputControl : UserControl
    {
        public PersonInfoInputControl()
        {
            InitializeComponent();
            DataContext = new PersonInfoViewModel();
        }
    }
}
