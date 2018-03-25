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
        public Exercise exercise { get; set; }
        public int series { get; set; }
        public int repetition { get; set; }
        public int weight { get; set; }
        public int TrainingId { get; set; }

    }
}
