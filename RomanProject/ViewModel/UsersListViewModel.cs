using System;
using System.Collections.Generic;
using RomanProject.Tools;
using System.Collections.ObjectModel;
using System.Linq;
using RomanProject.Model;
using System.Windows.Forms;
using RomanProject.Tools.Managers;
using RomanProject.Tools.Navigation;
using System.Threading.Tasks;
using System.Threading;

namespace RomanProject.ViewModel
{
    class UsersListViewModel:BaseViewModel,IUserListOwner
    {
        #region fields
        private ObservableCollection<Person> _users;
      
        private string _nameFilter;
        private string _surnameFilter;
        private string _emailFilter;
        private DateTime _dateTimeFilter;
        private string _isAdultFilter;
        private string _sunSignFilter;
        private string _chineaseSignFilter;
        private string _isBirthdayTodayFilter;

        private bool _nameSort;
        private bool _surnameSort;
        private bool _emailSort;
        private bool _birthdayDateSort;
        private bool _isAdultSort;
        private bool _sunSignSort;
        private bool _chineaseSignSort;
        private bool _isBirthdayTodaySort;

        private RelayCommand<object> _filterCommand;
        private RelayCommand<object> _resetCommand;
        private RelayCommand<object> _sortCommand;
        private RelayCommand<object> _addCommand;
        private RelayCommand<object> _editCommand;
        private RelayCommand<object> _removeCommand;

        private Person _selected;
        #endregion

        #region properties
        public ObservableCollection<Person> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public string NameFilter
        {
            set
            {
                _nameFilter = value;
            }
        }

        public string SurnameFilter
        {
           set
            {
                _surnameFilter = value;
            }
        }

        public string EMailFilter
        {
           set
            {
                _emailFilter = value;
            }
        }

        public DateTime DateTimeFilter
        {
            set
            {
                _dateTimeFilter = value;
            }
        }

        public string IsAdultFilter
        {
            set { _isAdultFilter = value; }
        }

        public string SunSignFilter
        {
         set
            {
                _sunSignFilter = value;
            }
        }

        public string ChineaseSignFilter
        {
           
            set
            {
                _chineaseSignFilter = value;
            }
        }

        public string IsBirthdayTodayFilter
        {
          set
            {
                _isBirthdayTodayFilter = value;
            }
        }


        public bool NameSort
        {
            set
            {
                _nameSort = value;
            }
        }

        public bool SurnameSort
        {
            set { _surnameSort = value; }
        }

        public bool EMailSort
        {
            set
            {
                _emailSort = value;
            }
        }

        public bool BirthdayDateSort
        {
            set
            {
                _birthdayDateSort = value;
            }
        }

       public bool IsAdultSort
        {
            set
            {
                _isAdultSort = value;
            }
        }

        public bool IsBirthdayTodaySort
        {
            set
            {
                _isBirthdayTodaySort = value;
            }
        }

        public bool ChineaseSignSort
        {
            set
            {
                _chineaseSignSort = value;
            }
        }

        public bool SunSignSort
        {
            set
            {
                _sunSignSort = value;
            }
        }

        public Person Selected
        {
            set
            {
                _selected = value;
                 UserListManager.PersonToEdit = _selected;
            }
        }

        public RelayCommand<object> FilterCommand
        {
            get
            {
                return _filterCommand ?? (_filterCommand = new RelayCommand<object>(
                           Filter, o => true));
            }
        }

        public RelayCommand<object> ResetCommand
        {
            get
            {
                return _resetCommand ?? (_resetCommand = new RelayCommand<object>(
                           Reset, o => true));
            }
        }

        public RelayCommand<object> SortCommand
        {
            get
            {
                return _sortCommand ?? (_sortCommand = new RelayCommand<object>(
                           Sort, o => true));
            }
        }

        public RelayCommand<object> AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand<object>(
                           OpenAddWindow, o => true));
            }
        }

        public RelayCommand<object> EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand = new RelayCommand<object>(
                           OpenEditWindow, o => _selected != null));
            }
        }

        public RelayCommand<object> RemoveCommand
        {
            get
            {
                return _removeCommand ?? (_removeCommand = new RelayCommand<object>(
                           Delete, o => _selected!=null));
            }
        }
        #endregion

        internal UsersListViewModel()
        {
            _users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
            UserListManager.Initialize(this);
        }

      
     
        private void Filter(object obj)
        {
            var res = StationManager.DataStorage.UsersList;
            res = FilterWithName(res);
            res = FilterWithSurname(res);
            res = FilterWithEmail(res);
            res = FilterWithBirthdayDate(res);
            res = FilterWithIsAdult(res);
            res = FilterWithSunSign(res);
            res = FilterWithChineaseSign(res);
            res = FilterWithIsBirthdayToday(res);
            Users = new ObservableCollection<Person>(res);
        }

        private List<Person> FilterWithName(List<Person> list)
        {
            if (!String.IsNullOrEmpty(_nameFilter))
            {
                return list.Where(person => person.Name.StartsWith(_nameFilter)).ToList();
            }
            return list;
        }

        private List<Person> FilterWithSurname(List<Person> list)
        {
            if (!String.IsNullOrEmpty(_surnameFilter))
            {
                return list.Where(person => person.Surname.StartsWith(_surnameFilter)).ToList();
            }
            return list;
        }

        private List<Person> FilterWithEmail(List<Person> list)
        {
            if (!String.IsNullOrEmpty(_emailFilter))
            {
                return list.Where(person => person.EMail.StartsWith(_emailFilter)).ToList();
            }
            return list;
        }

        private List<Person> FilterWithBirthdayDate(List<Person> list)
        {
            if (_dateTimeFilter != default(DateTime))
            {
                return list.Where(person => person.BirthdayDate == _dateTimeFilter).ToList();
            }
            return list;
        }

        private List<Person> FilterWithIsAdult(List<Person> list)
        {
            if (!String.IsNullOrEmpty(_isAdultFilter))
            {
                bool? isAdult = TryConvertToBool(_isAdultFilter);
                if (isAdult != null)
                {
                    return list.Where(person => person.IsAdult == isAdult.Value).ToList();
                }
            }
            return list;
        }

        private List<Person> FilterWithSunSign(List<Person> list)
        {
            if (!String.IsNullOrEmpty(_sunSignFilter))
            {
                    return list.Where(person => person.SunSign == _sunSignFilter).ToList();
               }
            return list;
        }

        private List<Person> FilterWithChineaseSign(List<Person> list)
        {
            if (!String.IsNullOrEmpty(_chineaseSignFilter))
            {
                return list.Where(person => person.ChineaseSign == _chineaseSignFilter).ToList();
            }
            return list;
        }

        private List<Person> FilterWithIsBirthdayToday(List<Person> list)
        {
            if (!String.IsNullOrEmpty(_isBirthdayTodayFilter))
            {
                bool? isBirthdayTodayFilter = TryConvertToBool(_isBirthdayTodayFilter);
                if (isBirthdayTodayFilter != null)
                {
                    return list.Where(person => person.IsBirthday == isBirthdayTodayFilter.Value).ToList();
                }
            }
            return list;
        }

        private bool? TryConvertToBool(string toConvert)
        {
            try
            {
                bool res = Boolean.Parse(toConvert);
                return res;
            }
            catch (FormatException e)
            {
                MessageBox.Show("Bad argument " + toConvert);
            }
            return null;
        }

        private void Reset(object obj)
        {
            Users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
        }

        private void Sort(object obj)
        {
            var list = _users.ToList();
            if (_nameSort)
            {
               list.Sort((person, person1) => person.Name.CompareTo(person1.Name));
            }
            else if (_surnameSort)
            {
                list.Sort((person, person1) => person.Surname.CompareTo(person1.Surname));
            }
            else if (_emailSort)
            {
                list.Sort((person, person1) => person.EMail.CompareTo(person1.EMail));
            }
            else if (_birthdayDateSort)
            {
                list.Sort((person, person1) => person.BirthdayDate.CompareTo(person1.BirthdayDate));
            }
            else if (_isAdultSort)
            {
                list.Sort((person, person1) => person.IsAdult.CompareTo(person1.IsAdult));
            }
            else if (_sunSignSort)
            {
                list.Sort((person, person1) => Person.CompareSunSigns(person.SunSign,person1.SunSign));
            }
            else if (_chineaseSignSort)
            {
                list.Sort((person, person1) => Person.CompareChineaseSigns(person.ChineaseSign, person1.ChineaseSign));
            }
            else if (_isBirthdayTodaySort)
            {
                list.Sort((person, person1) => person.IsBirthday.CompareTo(person1.IsBirthday));
            }
            Users = new ObservableCollection<Person>(list);
        }

        private void OpenAddWindow(object obj)
        {
            UserListManager.PersonToEdit = null;
            NavigationManager.Instance.Navigate(ViewType.UserEditor);
        }

        private void OpenEditWindow(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.UserEditor);
        }

        private async void Delete(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
                StationManager.DataStorage.DeleteUser(_selected);
                Users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
            });
            LoaderManager.Instance.HideLoader();
            UserListManager.PersonToEdit = null;
        }
    }
}
