using RomanProject.Tools.DataStorage;
using RomanProject.Tools.Managers;
using RomanProject.Tools.Navigation;
using RomanProject.ViewModel;
using System.ComponentModel;
using System.Windows;
using System;
using System.Windows.Controls;
using RomanProject.Tools;

namespace RomanProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IContentOwner
    {
        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }

        public MainWindow()
        {
            InitializeComponent();
            InitializeApplication();
            DataContext = new MainWindowViewModel();
        }

        private void InitializeApplication()
        {
            StationManager.Initialize(new SerializedDataStorage());
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.Main);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            StationManager.CloseApp();
        }
    }
}
