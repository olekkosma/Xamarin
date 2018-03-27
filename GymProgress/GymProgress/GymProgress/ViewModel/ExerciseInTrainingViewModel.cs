using GymProgress.Database;
using GymProgress.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace GymProgress.ViewModel
{
    public class ExerciseInTrainingViewModel : BasicViewModel
    {
        private Exercise _exercise;
        public Exercise Exercise
        {
            get { return _exercise; }
            set
            {
                _exercise = value;
                OnPropertyChanged();
            }
        }

        private Training _training;
        public Training Training
        {
            get { return _training; }
            set
            {
                _training = value;
                OnPropertyChanged();
            }
        }

        private int _series;
        public int Series
        {
            get { return _series; }
            set
            {
                _series = value;
                OnPropertyChanged();
            }
        }

        private int _repetition;
        public int Repetition
        {
            get { return _repetition; }
            set
            {
                _repetition = value;
                OnPropertyChanged();
            }
        }

        private int _weight;
        public int Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                OnPropertyChanged();
            }
        }

        public ExerciseInTrainingViewModel()
        {
        }

        public Command AddCommand
        {
            get
            {
                return new Command(Add);
            }
        }
        public void Add()
        {
            //NEED validation
            ExerciseInTraining exer = new ExerciseInTraining { Series = Series, Repetition = Repetition, Weight = Weight, Exercisee = Exercise, Training = Training };
          
            Database.SaveExerciseInTrainingAsync(exer);
            Training.ExercisesInTraining.Add(exer);
            Database.SaveTrainingAsync(Training);
        }
    }
}
