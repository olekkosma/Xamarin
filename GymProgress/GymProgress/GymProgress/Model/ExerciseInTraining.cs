using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymProgress.Model
{
    [Table("ExerciseInTraining")]
    class ExerciseInTraining
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ManyToOne]
        public Exercise Exercise { get; set; }
        public int Series { get; set; }
        public int Repetition { get; set; }
        public int Weight { get; set; }

    }
}
