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

        public string PrintDesc()
        {
                return string.Format("Desc: {0} \n{1} ", this.Description,PrintExerCount());
        }
        public string DescExtended
        {
            get { return PrintDesc(); }
        }

        public string PrintExerCount()
        {
            return string.Format("Exercises: {0} ", this.ExercisesInTraining.Count);
        }
        public string ExerCountExtended
        {
            get { return PrintExerCount(); }
        }
    }
}
