using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Xamarin.Forms;
using GymProgress.Droid.Model;
using System.IO;
using SQLite;
using GymProgress.Model;

[assembly: Dependency(typeof(SQLiteHelper))]
namespace GymProgress.Droid.Model
{
    public class SQLiteHelper : ISQLiteHelper
    {
        public SQLiteHelper() { }
        public SQLiteAsyncConnection GetConnection()
        {
            var sqliteFileName = "GymDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLiteAsyncConnection(path);
            return conn;
        }
    }
}