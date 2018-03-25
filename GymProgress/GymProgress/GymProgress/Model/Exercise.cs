﻿using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymProgress.Model
{
    [Table("Exercise")]
    class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string name { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ExerciseInTraining> ExerInTraining { get; set; }
    }
}
