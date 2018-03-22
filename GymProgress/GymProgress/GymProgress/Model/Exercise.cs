using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymProgress.Model
{
    class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string name { get; set; }
    }
}
