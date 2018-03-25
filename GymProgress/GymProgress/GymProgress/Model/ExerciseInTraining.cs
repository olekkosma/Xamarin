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
        [ForeignKey(typeof(Exercise))]
        public int ExerciseId { get; set; }
        public int Series { get; set; }
        public int Repetition { get; set; }
        public int Weight { get; set; }
        [ManyToOne]
        public Exercise Exercisee { get; set; }

    }
}
