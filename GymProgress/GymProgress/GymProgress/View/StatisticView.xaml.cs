using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using Microcharts;
using Entry = Microcharts.Entry;
using Xamarin.Forms;
using GymProgress.ViewModel;
using GymProgress.Model;
using System.Linq;

namespace GymProgress.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticView : ContentPage
    {
        TrainingListViewModel vm;
        private List<Entry> entries = new List<Entry>();
        public void loadTrainings()
        {
            vm = BindingContext as TrainingListViewModel;
            var trainings = vm.Trainings;
            List<Training> trainingsSorted = trainings.OrderBy(o => o.Date).ToList();
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

        public StatisticView()
        {
            InitializeComponent();
            loadTrainings();
            Chart1.Chart = new LineChart() { Entries = entries };
            Chart1.Chart.LabelTextSize = 30;

        }
    }
}
