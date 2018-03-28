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
        private List<Entry> entries = new List<Entry>();
        public void LoadTrainings()
        {
            entries = TrainingListViewModel.entries;
        }

        public StatisticView()
        {
            InitializeComponent();
            LoadTrainings();
            Chart1.Chart = new LineChart() { Entries = entries };
            Chart1.Chart.LabelTextSize = 30;

        }
    }
}
