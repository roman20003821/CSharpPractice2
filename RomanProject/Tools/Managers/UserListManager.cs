using System.Collections.ObjectModel;
using RomanProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace RomanProject.Tools.Managers
{
   internal class UserListManager
    {
        private static Person _personToEdit;
        private static IUserListOwner _userListOwner;


        internal static Person PersonToEdit
        {
            get
            {
                return _personToEdit;
            }

            set
            {
                _personToEdit = value;
            }
        }

        internal static void Initialize(IUserListOwner owner)
        {
            _userListOwner = owner;
        }

        internal static void Reload(List<Person> persons)
        {
          _userListOwner.Users = new ObservableCollection<Person>(persons);
        }

    }
}
