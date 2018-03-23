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
    class ExerciseViewModel : INotifyPropertyChanged
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
        public ExerciseViewModel()
        {

            firstLoad();
            //Suggestions = exercises.ToList();
        }
        private async void loadList()
        {
          
            Suggestions = await Database.GetAllExercisesAsync();
        }
        
        private async void firstLoad()
        {

            exercises = await Database.GetAllExercisesAsync();
            Database.LoadSeedIfEmpty(exercises.Count);
            exercises = await Database.GetAllExercisesAsync();
            Suggestions = await Database.GetAllExercisesAsync();
        }
        public List<Exercise> exercises;

        private string _keyword;
        public string Keyword
        {
            get { return _keyword; }
            set
            {
                _keyword = value;
                OnPropertyChanged();
            }
        }

        private List<Exercise> _suggestions = new List<Exercise>();

        public List<Exercise> Suggestions
        {
            get { return _suggestions; }
            set
            {
                _suggestions = value;
                OnPropertyChanged();
            }
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
            if (_keyword.Length> 0)
            {
                  Suggestions = _suggestions.Where(c => c.name.ToLower().Contains(_keyword.ToLower())).ToList();

            }
            else
            {
                loadList();
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
            //NEED validation
            Database.SaveExerciseAsync(new Exercise { name = newExercise });

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
