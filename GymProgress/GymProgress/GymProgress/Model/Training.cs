﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymProgress.Model
{
    class Training
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public List<ExerciseInTraining> exercises { get; set; }
    }
}