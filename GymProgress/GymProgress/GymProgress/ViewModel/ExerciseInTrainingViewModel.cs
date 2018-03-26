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
    public class ExerciseInTrainingViewModel : INotifyPropertyChanged
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

        private Exercise _exercise;
        public Exercise Exercise
        {
            get { return _exercise; }
            set
            {
                _exercise = value;
                OnPropertyChanged();
            }
        }

        private int _series;
        public int Series
        {
            get { return _series; }
            set
            {
                _series = value;
                OnPropertyChanged();
            }
        }

        private int _repetition;
        public int Repetition
        {
            get { return _repetition; }
            set
            {
                _repetition = value;
                OnPropertyChanged();
            }
        }

        private int _weight;
        public int Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                OnPropertyChanged();
            }
        }

        public ExerciseInTrainingViewModel()
        {
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
            Database.SaveExerciseInTrainingAsync(new ExerciseInTraining { Series=Series,Repetition=Repetition,Weight=Weight,Exercisee=Exercise});
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
