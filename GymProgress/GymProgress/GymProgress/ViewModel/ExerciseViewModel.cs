﻿using GymProgress.Database;
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

        public List<Exercise> exercisesList;

        public ExerciseViewModel()
        {
            firstLoad();
        }
        private async void firstLoad()
        {
            exercisesList = await Database.GetAllExercisesAsync();
            Database.LoadSeedIfEmpty(exercisesList.Count);
            exercisesList = await Database.GetAllExercisesAsync();
            Suggestions = exercisesList.ToList();
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
            if (_keyword.Length> 0)
            {
                  Suggestions = exercisesList.Where(c => c.name.ToLower().Contains(_keyword.ToLower())).ToList();
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
            //NEED validation
            Database.SaveExerciseAsync(new Exercise { name = newExercise });
            UpdateListFromDatabase();
        }
        public Command<Exercise> DeleteCommand
        {
            get
            {
                return new Command<Exercise>(Delete);
            }
        }

        public void Delete(Exercise exerToDelete)
        {
            Database.DeleteExerciseAsync(exerToDelete);
            UpdateListFromDatabase();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
