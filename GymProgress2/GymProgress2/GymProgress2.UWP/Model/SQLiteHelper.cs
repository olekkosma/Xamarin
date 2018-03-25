using GymProgress2.Model;
using GymProgress2.UWP.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteHelper))]
namespace GymProgress2.UWP.Model
{
   
    public class SQLiteHelper : ISQLiteHelper
    {
        public SQLiteHelper() { }

        public SQLiteAsyncConnection GetConnection()
        {
            var sqliteFileName = "GymDB.db3";
            var path = Path.Combine(ApplicationData.
              Current.LocalFolder.Path, sqliteFileName);
            var conn = new SQLiteAsyncConnection(path);
            return conn;
        }
    }
}
