using RomanProject.Tools;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using RomanProject.Model;

namespace RomanProject.ViewModel
{
    class PersonInfoViewModel:BaseViewModel
    {
        #region constants
        private static readonly int MlsecondsToWait = 2000;
        #endregion

        #region fields
        private string _name;
        private string _surname;
        private string _eMail;
        private DateTime _birthdayDate = DateTime.Today;
        private bool _isAdult;
        private string _sunSign;
        private string _chineaseSign;
        private bool _isBirthday;
        private string _generalInfo;
        #region Commands
        private RelayCommand<object> _checkDate;
        #endregion
        #endregion

        #region properties
        public string Name
        {
            get { return _name; }
            private set
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
            private set
            {
                _eMail = value;
                OnPropertyChanged();
            }
        }

        public DateTime BirthdayDate
        {
            get { return _birthdayDate; }
            private set
            {
                _birthdayDate = value;
                OnPropertyChanged();
            }
        }

        public bool IsAdult
        {
            get { return _isAdult; }
            private set
            {
                _isAdult = value;
                OnPropertyChanged();
            }
        }

        public string SunSign
        {
            get
            {
               return _sunSign;
            }
           private set
            {
                _sunSign = value;
                OnPropertyChanged();
            }
        }

        public string ChineaseSign
        {
            get { return _chineaseSign; }
            private set
            {
                _chineaseSign = value;
                OnPropertyChanged();
            }
        }

        public bool IsBirthday
        {
            get { return _isBirthday; }
            private set
            {
                _isBirthday = value;
                OnPropertyChanged();
            }
        }

        public string GeneralInfo
        {
            get { return _generalInfo; }
            private set
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
                if (!IsDateCorrect(_birthdayDate))
                {
                    MessageBox.Show($"Incorrect date: {_birthdayDate.ToShortDateString()}");
                    return false;
                }
                person = new Person(_name, _surname, _eMail, _birthdayDate);
                return true;
            });
           if (res)
           {
               ParseToFieds(person);
               CheckIfShowBirthdayMessage(person);
           }
           LoaderManager.Instance.HideLoader();
        }

 

        private bool IsDateCorrect(DateTime date)
        {
            return date.CompareTo(DateTime.Today) <= 0 && DateTime.Today.Year - date.Year < 135;
        }

        private void ParseToFieds(Person person)
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
