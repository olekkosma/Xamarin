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
    class ExerciseInTrainingViewModel : INotifyPropertyChanged
    {
        private static ExerciseDatabase database;
        public static ExerciseDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ExerciseDatabase();
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

        public ExerciseInTrainingViewModel()
        {
            FirstLoad();
        }

        private async void FirstLoad()
        {
            Exercises = await Database.GetAllExercisesInTrainingsAsync();
           /* Exercises = new List<ExerciseInTraining> { new ExerciseInTraining
            {
                Weight=12,
                Series=5,
                Exercisee = new Exercise{name="nowe cwiczenie"},
            },
             new ExerciseInTraining
            {
                Weight=12,
                Series=5,
                Exercisee = new Exercise{name="drugie nowe cwiczenie"},
            }
            };*/
        }

        private async void UpdateListFromDatabase()
        {
            Exercises = await Database.GetAllExercisesInTrainingsAsync();
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
