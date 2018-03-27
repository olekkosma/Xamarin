using GymProgress.Database;
using GymProgress.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace GymProgress.ViewModel
{
    class TrainingViewModel : BasicViewModel
    {
        private Training _training;

        public Training Training
        {
            get { return _training; }
            set
            {
                _training = value;
                Descritpion = value.Description;
                Date = value.Date;
                UpdateList(value);
                Exercises = value.ExercisesInTraining;
                //Exercises = new List<ExerciseInTraining>();
                OnPropertyChanged();
            }
        }

        public async void UpdateList(Training training)
        {
                foreach (ExerciseInTraining exerInTraining in training.ExercisesInTraining)
                {
                    exerInTraining.Exercisee = await Database.GetExerForExerInTrainingAsync(exerInTraining.ExerciseId);
                }
        }

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

        public TrainingViewModel()
        {
                //UpdateListFromDatabase();
                Descritpion = "- no desc -";
                Date = DateTime.Now;
            Exercises = new List<ExerciseInTraining>();
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
            if (_training == null)
            {
                //NEED validation
                Database.SaveTrainingAsync(new Training { Description = Descritpion, Date = Date, ExercisesInTraining = Exercises });
            }
            else
            {
                _training.Description = Descritpion;
                _training.Date = Date;
                _training.ExercisesInTraining = Exercises;
                Database.SaveTrainingAsync(_training);
            }
                UpdateListFromDatabase();
        }
        
        public async void UpdateListFromDatabase()
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
