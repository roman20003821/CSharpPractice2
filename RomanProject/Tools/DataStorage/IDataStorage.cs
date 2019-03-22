using RomanProject.Model;
using System.Collections.Generic;

namespace RomanProject.Tools.DataStorage
{
   internal interface IDataStorage
   {
            void AddOrUptateIfExists(Person user);
            void AddUser(Person user);
            void DeleteUser(Person user);
            List<Person> UsersList { get; }
        }
}
