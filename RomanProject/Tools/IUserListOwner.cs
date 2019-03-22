using System.Collections.ObjectModel;
using RomanProject.Model;

namespace RomanProject.Tools
{
  interface IUserListOwner
    {
        ObservableCollection<Person> Users { set; get; }
    }
}
