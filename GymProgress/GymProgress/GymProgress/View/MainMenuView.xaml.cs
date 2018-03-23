using GymProgress.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GymProgress
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private async void Training_Clicked(object sender, EventArgs e)
        {
        }
        private async void TrainingList_Clicked(object sender, EventArgs e)
        {
        }

        private async void Exercises_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExerciseView());
        }
        private async void Statistics_Clicked(object sender, EventArgs e)
        {
        }
    }
}
