using GymProgress.Model;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Entry = Microcharts.Entry;
namespace GymProgress.ViewModel
{
    class TrainingListViewModel : BasicViewModel
    {
        public static List<Entry> entries = new List<Entry>();
        private List<Training> _trainings = new List<Training>();
        public List<Training> Trainings
        {
            get
            {
                return _trainings;
            }
            set
            {
                _trainings = value;
                OnPropertyChanged();
            }
        }

        public TrainingListViewModel()
        {
            UpdateListFromDatabase();
            UpdateChildrenForTraining();
        }

        public async void UpdateChildrenForTraining()
        {
            _trainings = await Database.GetAllTrainingsAsync();
            foreach (Training training in _trainings)
            {
                foreach (ExerciseInTraining exerInTraining in training.ExercisesInTraining)
                {
                    exerInTraining.Exercisee = await Database.GetExerForExerInTrainingAsync(exerInTraining.ExerciseId);
                }
            }
            FillEntriesWithData();
        }
        public void FillEntriesWithData()
        {
            entries = new List<Entry>();
            List<Training> trainingsSorted = _trainings.OrderBy(o => o.Date).ToList();
            Random random = new Random();
            foreach (Training training in trainingsSorted)
            {
                int sum = 0;
                foreach (ExerciseInTraining exerInTraining in training.ExercisesInTraining)
                {
                    sum += exerInTraining.Repetition * exerInTraining.Series * exerInTraining.Weight;
                }
                var color = String.Format("#{0:X6}", random.Next(0x1000000));
                entries.Add(new Entry(sum) { ValueLabel = sum.ToString(), Label = training.Date.ToString("yyy-MM-dd"), Color = SKColor.Parse(color) });
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
            foreach (Training training in Trainings)
            {
                if (training.ExercisesInTraining.Count < 1)
                {
                    loadTwice = true;
                    Delete(training);
                }
            }
            if (loadTwice) Trainings = await Database.GetAllTrainingsAsync();
        }
    }
}
