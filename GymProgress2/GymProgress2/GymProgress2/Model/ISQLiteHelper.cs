using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymProgress2.Model
{
    public interface ISQLiteHelper
    {
        SQLiteAsyncConnection GetConnection();
    }
}
