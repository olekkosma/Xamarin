using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models
{

    public class Emplyee
    {
        [PrimaryKey,AutoIncrement]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public int Age { get; set; }
    }
}
