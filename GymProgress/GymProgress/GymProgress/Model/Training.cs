using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymProgress.Model
{
    [Table("Training")]
    public class Training
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead)]
        public List<ExerciseInTraining> ExercisesInTraining { get; set; }

    }
}
