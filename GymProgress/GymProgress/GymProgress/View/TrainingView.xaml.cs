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
    public partial class TrainingView : ContentPage
    {
        TrainingViewModel vm;

        public TrainingView()
        {
            InitializeComponent();
            vm = BindingContext as TrainingViewModel;
            vm.initNewTraining();
        }

        public TrainingView(Training training)
        {
            InitializeComponent();
            vm = BindingContext as TrainingViewModel;
            vm.Training = training;

        }

        private async void AddExer_Clicked(object sender, EventArgs e)
        {
            vm = BindingContext as TrainingViewModel;
            await Navigation.PushAsync(new AddExericeView(vm.Training));
        }

        private async void DeleteExerInTraining_Clicked(object sender, TextChangedEventArgs e)
        {
            var answer = await DisplayAlert("Delete?", "Are you sure you want to delete?", "Yes", "No");
            if (answer)
            {
                var button = sender as Button;
                var exer = button.BindingContext as ExerciseInTraining;
                var vm = BindingContext as TrainingViewModel;
                vm.DeleteCommand.Execute(exer);
            }
        }
        private void AddTraining_Clicked(object sender, EventArgs e)
        {

            var vm = BindingContext as TrainingViewModel;

            if (DateTime.Compare(vm.Date, DateTime.Now) > 0)
            {
                DateErrorLabel.Text = "Date is from the future!Wrong!";

            }
            else
            {
                DateErrorLabel.Text = "";
                vm.AddCommand.Execute(null);
                Navigation.PopAsync();
            }
        }
        protected override void OnAppearing()
        {
            var vm = BindingContext as TrainingViewModel;
            vm.UpdateListFromDatabase();
        }
    }
}