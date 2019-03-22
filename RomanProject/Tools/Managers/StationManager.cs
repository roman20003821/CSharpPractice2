using RomanProject.Tools.DataStorage;
using System;
using System.Windows;
using RomanProject.Model;

namespace RomanProject.Tools.Managers
{
    class StationManager
    { 
        public static event Action StopThreads;

        private static IDataStorage _dataStorage;

        internal static IDataStorage DataStorage
        {
            get { return _dataStorage; }
        }

        internal static void Initialize(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

       

        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            StopThreads?.Invoke();
            Environment.Exit(1);
        }
    }
}
