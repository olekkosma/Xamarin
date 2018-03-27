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
    class ExerciseViewModel : BasicViewModel
    {
        private string _keyword;
        private List<Exercise> _suggestions = new List<Exercise>();
        public List<Exercise> exercisesList;
        public string Keyword
        {
            get { return _keyword; }
            set
            {
                _keyword = value;
                OnPropertyChanged();
            }
        }

        public List<Exercise> Suggestions
        {
            get { return _suggestions; }
            set
            {
                _suggestions = value;
                OnPropertyChanged();
            }
        }

        public ExerciseViewModel()
        {
            FirstLoad();
        }
        private async void FirstLoad()
        {
            exercisesList = await Database.GetAllExercisesAsync();
            Database.LoadSeedIfEmpty(exercisesList.Count);
            UpdateListFromDatabase();
        }

        private async void UpdateListFromDatabase()
        {
            exercisesList = await Database.GetAllExercisesAsync();
            Suggestions = exercisesList.ToList();
        }

        public Command SearchCommand
        {
            get
            {
                return new Command(Search);
            }
        }
        public void Search()
        {
            if (_keyword.Length > 0)
            {
                Suggestions = exercisesList.Where(c => c.Name.ToLower().Contains(_keyword.ToLower())).ToList();
            }
            else
            {
                Suggestions = exercisesList;
            }
        }
        public Command<string> AddCommand
        {
            get
            {
                return new Command<string>(Add);
            }
        }
        public void Add(string newExercise)
        {
            Database.SaveExerciseAsync(new Exercise { Name = newExercise });
            UpdateListFromDatabase();
        }
        
        public Command<Exercise> DeleteCommand
        {
            get
            {
                return new Command<Exercise>(Delete);
            }
        }

        public async void Delete(Exercise exerToDelete)
        {
            await Database.DeleteExerciseAsync(exerToDelete);
            UpdateListFromDatabase();
        }
    }
}
