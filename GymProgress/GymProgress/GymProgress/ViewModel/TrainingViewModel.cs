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
    class TrainingViewModel
    {
        private static GymDatabase database;
        public static GymDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new GymDatabase();
                }
                return database;
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

        public TrainingViewModel()
        {
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


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
