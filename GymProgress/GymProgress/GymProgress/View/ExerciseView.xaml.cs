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
	public partial class ExerciseView : ContentPage
	{
        
		public ExerciseView ()
		{
			InitializeComponent ();
		}
        private double width;
        private double height;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    mainRowGrid.RowDefinitions.Clear();
                    mainRowGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(14, GridUnitType.Star)});
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

        private void SearchBar_OnTextChanged(object sender,TextChangedEventArgs e)
        {
            var vm = BindingContext as ExerciseViewModel;
            vm.SearchCommand.Execute(null);
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
    }
}