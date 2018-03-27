using GymProgress.Model;
using GymProgress.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymProgress.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExericeView : ContentPage
    {
        public AddExericeView()
        {
            InitializeComponent();
        }

        public AddExericeView(Training training)
        {
            InitializeComponent();
            var vm = BindingContext as ExerciseInTrainingViewModel;
            vm.Training = training;
        }
        public AddExericeView(Exercise exer)
        {
            InitializeComponent();
            var vm = BindingContext as ExerciseInTrainingViewModel;

            vm.Exercise = exer;
        }

        private async void SelectExercise_Clicked(object sender, EventArgs e)
        {
            var vm = BindingContext as ExerciseInTrainingViewModel;
            await Navigation.PushAsync(new ExerciseView(true, vm));
        }

        private void AddExerciseInTraining_Clicked(object sender, EventArgs e)
        {
            var vm = BindingContext as ExerciseInTrainingViewModel;
            if (vm.Exercise == null)
            {
                ExerciseErrorLabel.Text = "Select exercise!Wrong!";
            }
            else
            {
                ExerciseErrorLabel.Text = "";
                if (vm.Series <= 0)
                {
                    SeriesErrorLabel.Text = "Series value need to be positive!Wrong!";
                }
                else
                {
                    SeriesErrorLabel.Text = "";
                    if (vm.Repetition <= 0)
                    {
                        RepetitionErrorLabel.Text = " Repetition value need to be positive!Wrong!";
                    }
                    else
                    {
                        RepetitionErrorLabel.Text = "";
                        if (vm.Weight < 0)
                        {
                            WeightErrorLabel.Text = " Weight value need to be  not negative!Wrong!";
                        }
                        else
                        {
                            WeightErrorLabel.Text = "";
                            vm.AddCommand.Execute(null);
                            Navigation.PopAsync();
                        }
                    }
                }
            }
        }
    }
}