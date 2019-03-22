using System;
using System.Collections.Generic;
using RomanProject.Model;
using System.IO;
using System.Linq;
using System.Windows;
using RomanProject.Tools.Managers;

namespace RomanProject.Tools.DataStorage
{
    class SerializedDataStorage:IDataStorage
    {
        private readonly List<Person> _users;

        internal SerializedDataStorage()
        {
            try
            {
                _users = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _users = new List<Person>();
                _users.AddRange(UserGenerator.GenerateUsers(50));
                SaveChanges();
            }
        }

        public void AddOrUptateIfExists(Person user)
        {
            if (_users.Contains(user))
            {
                _users.Remove(user);
            }
            AddUser(user);
        }

        public void AddUser(Person user)
        {
            _users.Add(user);
            SaveChanges();
        }

        public void DeleteUser(Person person)
        {
            _users.Remove(person);
            SaveChanges();
        }

        public List<Person> UsersList
        {
            get
            {
                return _users.ToList();
            }
        }

        private void SaveChanges()
        {
            SerializationManager.Serialize(_users, FileFolderHelper.StorageFilePath);
        }
    }
}
