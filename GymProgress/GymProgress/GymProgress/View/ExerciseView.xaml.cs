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