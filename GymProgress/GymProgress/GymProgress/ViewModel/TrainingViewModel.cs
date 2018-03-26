﻿using GymProgress.Database;
using GymProgress.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace GymProgress.ViewModel
{
    class TrainingViewModel : BasicViewModel
    {

        private List<ExerciseInTraining> _exercises = new List<ExerciseInTraining>();
        public List<ExerciseInTraining> Exercises
        {
            get { return _exercises; }
            set
            {
                _exercises = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Descritpion
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        private List<string> _exercisesString = new List<string>();

        public List<string> ExercisesString
        {
            get { return _exercisesString; }
            set
            {
                _exercisesString = value;
                OnPropertyChanged();
            }
        }

        public TrainingViewModel()
        {
            UpdateListFromDatabase();
            //foreach (ExerciseInTraining exer in Exercises)
           // {
           //     ExercisesString.Add(string.Format("\b{0} \n Series: {1}  Repetition: {2}  Weight: {3}", exer.Exercisee.Name, exer.Series, exer.Repetition, exer.Weight));
           // }
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
                Database.SaveTrainingAsync(new Training { Description = Descritpion ,Date=Date,Exercises=Exercises});
                UpdateListFromDatabase();
        }
        
        private async void UpdateListFromDatabase()
        {
            Exercises = await Database.GetAllExercisesInTrainingAsync();
        }

        public Command<ExerciseInTraining> DeleteCommand
        {
            get
            {
                return new Command<ExerciseInTraining>(Delete);
            }
        }

        public void Delete(ExerciseInTraining exerToDelete)
        {
            Database.DeleteExerciseInTrainingAsync(exerToDelete);
            UpdateListFromDatabase();
        }
    }
}