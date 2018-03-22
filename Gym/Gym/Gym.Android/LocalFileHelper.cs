using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System;
using Xamarin.Forms;
using System.IO;
using Gym.Droid;

[assembly: Dependency(typeof(LocalFileHelper))]
namespace Gym.Droid
{
    public class LocalFileHelper : ILocalFileHelper
    {
        public LocalFileHelper() { }
        public SQLite.SQLiteAsyncConnection GetConnection()
        {
            var sqliteFileName = "TestDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLite.SQLiteAsyncConnection(path);
            return conn;
        }
    }
}