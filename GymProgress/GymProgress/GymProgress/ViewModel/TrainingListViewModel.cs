using GymProgress.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GymProgress.ViewModel
{
    class TrainingListViewModel : BasicViewModel
    {
        private List<Training> _trainings = new List<Training>();
        public List<Training> Trainings
        {
            get { return _trainings; }
            set
            {
                _trainings = value;
                OnPropertyChanged();
            }
        }

        public TrainingListViewModel()
        {
            UpdateListFromDatabase();
            UpdateList();
        }

        public async void UpdateList()
        {
            //UpdateListFromDatabase();
            _trainings = await Database.GetAllTrainingsAsync();
            foreach (Training training in _trainings)
            {
                foreach (ExerciseInTraining exerInTraining in training.ExercisesInTraining)
                {
                    exerInTraining.Exercisee = await Database.GetExerForExerInTrainingAsync(exerInTraining.ExerciseId);
                }
            }
        }

        public Command<Training> DeleteCommand
        {
            get
            {
                return new Command<Training>(Delete);
            }
        }

        public void Delete(Training exerToDelete)
        {
            Database.DeleteTrainingAsync(exerToDelete);
            UpdateListFromDatabase();
        }

        public async void UpdateListFromDatabase()
        {
            bool loadTwice = false;
            Trainings = await Database.GetAllTrainingsAsync();
            foreach(Training training in Trainings)
            {
                if (training.ExercisesInTraining.Count < 1)
                {
                    loadTwice = true;
                    Delete(training);
                }
            }
            if(loadTwice) Trainings = await Database.GetAllTrainingsAsync();
            
        }
    }
}
