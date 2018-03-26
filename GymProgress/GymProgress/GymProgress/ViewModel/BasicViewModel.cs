using GymProgress.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GymProgress.ViewModel
{
    public class BasicViewModel : INotifyPropertyChanged
    {
        private static GymDatabase database;
        public static GymDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new GymDatabase();
                }
                return database;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
