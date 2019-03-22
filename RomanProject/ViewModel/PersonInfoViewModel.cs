using RomanProject.Tools;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using RomanProject.Model;
using RomanProject.Tools.Exceptions;
using RomanProject.Tools.Managers;
using RomanProject.Tools.Navigation;

namespace RomanProject.ViewModel
{
    class PersonInfoViewModel : BaseViewModel
    {
        #region constants
        private static readonly int MlsecondsToWait = 1000;
        #endregion

        #region fields
        private string _name;
        private string _surname;
        private string _eMail;
        private DateTime _birthdayDate = DateTime.Today;
        #region Commands
        private RelayCommand<object> _saveCommand;
        private RelayCommand<object> _cancelCommand;
        #endregion
        #endregion

        #region properties
        public string Name
        {
            get { return _name;}
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }

            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string EMail
        {
            get { return _eMail; }
            set
            {
                _eMail = value;
                OnPropertyChanged();
            }
        }

        public DateTime BirthdayDate
        {
            get { return _birthdayDate;}
            set
            {
                _birthdayDate = value;
                OnPropertyChanged();
            }
        }
        
        #region Commands
        public RelayCommand<object> SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand<object>(
                          ProceedClick, CanExecute));
            }
        }

        public RelayCommand<object> CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(
                           Cancel, o => true));
            }
        }
        #endregion
        #endregion

        internal PersonInfoViewModel()
        {
            Person personToEdit = UserListManager.PersonToEdit;
            ParseToFields(personToEdit);
        }

        private bool CanExecute(Object obj)
        {
            return !string.IsNullOrWhiteSpace(_name) && !string.IsNullOrWhiteSpace(_surname) &&
                   !string.IsNullOrWhiteSpace(_eMail);
        }

        private async void ProceedClick(Object obj)
        {
            LoaderManager.Instance.ShowLoader();
            Person person = null;
            bool res = await Task.Run(() =>
            {
                Thread.Sleep(MlsecondsToWait);
                person = TryToCreatePerson(_name, _surname, _eMail, _birthdayDate);
                return person != null;
            });
            LoaderManager.Instance.HideLoader();
            if (res)
            {
                Clear();
                NavigationManager.Instance.Navigate(ViewType.Main);
            }
        }

        private Person TryToCreatePerson(string name, string surname, string eMail, DateTime birthdayDate)
        {
            Person person = null;
            try
            {
                person = new Person(name, surname, eMail, birthdayDate);
                StationManager.DataStorage.AddOrUptateIfExists(person);
                UserListManager.Reload(StationManager.DataStorage.UsersList.ToList());
            }
            catch (PersonPropertyException e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e);
            }
            return person;
        }

        private void Cancel(object obj)
        {
            Clear();
            NavigationManager.Instance.Navigate(ViewType.Main);
        }

        private void Clear()
        {
            Name = "";
            Surname = "";
            EMail = "";
            BirthdayDate = default(DateTime);
        }

        private void ParseToFields(Person person)
        {
            if (person != null)
            {
                Name = person.Name;
                Surname = person.Surname;
                EMail = person.EMail;
                BirthdayDate = person.BirthdayDate;
            }
        }
    }
}
