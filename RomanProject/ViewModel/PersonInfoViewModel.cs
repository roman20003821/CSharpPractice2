using RomanProject.Tools;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using RomanProject.Model;
using RomanProject.Tools.Exceptions;

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
        private string _generalInfo;
        #region Commands
        private RelayCommand<object> _checkDate;
        #endregion
        #endregion

        #region properties
        public string Name
        {
            get { return _name; }
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
            get { return _birthdayDate; }
            set
            {
                _birthdayDate = value;
                OnPropertyChanged();
            }
        }


        public string GeneralInfo
        {
            get { return _generalInfo; }
            set
            {
                _generalInfo = value;
                OnPropertyChanged();
            }
        }

        #region Commands
        public RelayCommand<object> CheckDate
        {
            get
            {
                return _checkDate ?? (_checkDate = new RelayCommand<object>(
                          ProceedClick, CanExecute));
            }
        }
        #endregion
        #endregion

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
            if (res)
            {
                ParseToFields(person);
                CheckIfShowBirthdayMessage(person);
            }
            LoaderManager.Instance.HideLoader();
        }

        private Person TryToCreatePerson(string name, string surname, string eMail, DateTime birthdayDate)
        {
            Person person = null;
            try
            {
                person = new Person(name, surname, eMail, birthdayDate);
            }
            catch (PersonPropertyException e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e);
            }
            return person;
        }



        private void ParseToFields(Person person)
        {
            GeneralInfo = person.ToString();
        }

        private void CheckIfShowBirthdayMessage(Person person)
        {
            if (person.IsBirthday)
            {
                MessageBox.Show("Happy birthday!!!");
            }
        }
    }
}
