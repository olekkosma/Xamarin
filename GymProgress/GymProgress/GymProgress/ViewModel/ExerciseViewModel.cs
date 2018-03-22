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

        public ExerciseViewModel()
        {
            Suggestions = exercises;
        }
        List<string> exercises = new List<string>
        {
            "Bench press","Pull up","Dead lift","Squat","Push up"
        };

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

        private List<string> _suggestions = new List<string>();

        public List<string> Suggestions
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
                  Suggestions = exercises.Where(c => c.ToLower().Contains(_keyword.ToLower())).ToList();

            }
            else
            {
                Suggestions = exercises;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
