using GymProgress.Model;
using System;
using System.Collections.Generic;
using System.Text;

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
        }

        public async void UpdateListFromDatabase()
        {
            Trainings = await Database.GetAllTrainingsAsync();
        }
    }
}
