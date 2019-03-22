﻿using System.Windows.Controls;
using RomanProject.Tools.Navigation;
using RomanProject.ViewModel;

namespace RomanProject.View
{
    /// <summary>
    /// Interaction logic for PersonInfoInput.xaml
    /// </summary>
    public partial class PersonInfoInputControl : UserControl,INavigatable
    {
        public PersonInfoInputControl()
        {
            InitializeComponent();
            DataContext = new PersonInfoViewModel();
        }
    }
}
