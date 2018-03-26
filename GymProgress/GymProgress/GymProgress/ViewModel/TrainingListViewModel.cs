﻿using GymProgress.Model;
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
            Trainings = await Database.GetAllTrainingsAsync();
        }
    }
}
