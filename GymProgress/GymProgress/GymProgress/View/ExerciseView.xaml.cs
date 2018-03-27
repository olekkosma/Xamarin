using GymProgress.Model;
using GymProgress.ViewModel;
using Newtonsoft.Json;
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
	public partial class ExerciseView : ContentPage
	{
        bool IsComingFromTrainingSession = false;
        ExerciseInTrainingViewModel Vm;
        private double width;
        private double height;
        public ExerciseView ()
		{
			InitializeComponent ();
		}
        public ExerciseView(bool value, ExerciseInTrainingViewModel vm)
        {
            InitializeComponent();
            IsComingFromTrainingSession = value;
            Vm = vm;
        }

        private void SearchBar_OnTextChanged(object sender,TextChangedEventArgs e)
        {
            var vm = BindingContext as ExerciseViewModel;
            vm.SearchCommand.Execute(null);
            var searchBar = sender as SearchBar;

            string newExer = searchBar.Text;
            List<Exercise> list = vm.exercisesList;
            if (newExer.Length < 2  || IsAlreadyDefined(list,newExer))
            {
                AddButton.IsEnabled = false;
            }
            else
            {
                AddButton.IsEnabled = true;
            }
        }
        public bool IsAlreadyDefined(List<Exercise> list,string newExer)
        {
            foreach(Exercise exer in list)
            {
                if (exer.Name.ToLower().Equals(newExer.ToLower()))
                {
                    return true;
                }
            }
            return false;

        }
        private void ExerciseChoossed_Clicked(object sender, ItemTappedEventArgs e)
        {
            if (IsComingFromTrainingSession)
            {
                IsComingFromTrainingSession = false;
                var exer = e.Item as Exercise;
                Vm.Exercise = exer;
                Navigation.PopAsync();
            }
        }

        private async void DeleteButton_Clicked(object sender, TextChangedEventArgs e)
        {
            var answer = await DisplayAlert("Delete?", "Are you sure you want to delete?", "Yes", "No");
            if (answer)
            {
                var button = sender as Button;
                var exer = button.BindingContext as Exercise;
                var vm = BindingContext as ExerciseViewModel;
                vm.DeleteCommand.Execute(exer);
            }
        }

        private void AddButton_Clicked(object sender, TextChangedEventArgs e)
        {
            var vm = BindingContext as ExerciseViewModel;
            vm.AddCommand.Execute(ExercisesSearchBar.Text);
        }

        protected override void OnSizeAllocated(double width, double height)  // when screen is rotated, no acces via xaml
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    mainRowGrid.RowDefinitions.Clear();
                    mainRowGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(14, GridUnitType.Star) });
                    mainRowGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(16, GridUnitType.Star) });
                    mainRowGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(70, GridUnitType.Star) });
                }
                else
                {
                    mainRowGrid.RowDefinitions.Clear();
                    mainRowGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(8, GridUnitType.Star) });
                    mainRowGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(8, GridUnitType.Star) });
                    mainRowGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(84, GridUnitType.Star) });
                }
            }
        }
    }
}