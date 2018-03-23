﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymProgress.Model
{
    class ExerciseInTraining
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Exercise exercise { get; set; }
        public int series { get; set; }
        public int repetition { get; set; }
        public int weight { get; set; }

    }
}
