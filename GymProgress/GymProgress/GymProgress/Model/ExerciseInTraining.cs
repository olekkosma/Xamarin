using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymProgress.Model
{
    [Table("ExerciseInTraining")]
    public class ExerciseInTraining
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Exercise))]
        public int ExerciseId { get; set; }
        [ForeignKey(typeof(Training))]
        public int TrainingId { get; set; }
        public int Series { get; set; }
        public int Repetition { get; set; }
        public int Weight { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Exercise Exercisee { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Training Training { get; set; }

        public string Print()
        {
            //return string.Format("{0} TrainingID: {1} ownId: {2} \n Series: {3}  Repetition: {4}  Weight: {5}", this.Exercisee.Name,this.TrainingId,this.Id, this.Series, this.Repetition, this.Weight);
            if (this.Exercisee != null)
            {
                return string.Format("{0} \n Series: {1}  Repetition: {2}  Weight: {3}", this.Exercisee.Name, this.Series, this.Repetition, this.Weight);
            }
            else
            {
                return "";
            }
        }
        public string MyText
        {
            get { return Print(); }
        }
    }
}
