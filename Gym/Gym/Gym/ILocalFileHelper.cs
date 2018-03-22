using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym
{
    public interface ILocalFileHelper
    {
        SQLiteAsyncConnection GetConnection();

    }
}
