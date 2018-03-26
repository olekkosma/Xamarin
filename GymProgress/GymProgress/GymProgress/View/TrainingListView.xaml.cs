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
	public partial class TrainingListView : ContentPage
	{
		public TrainingListView ()
		{
			InitializeComponent ();
		}

        private async void DeleteButton_Clicked(object sender, TextChangedEventArgs e)
        {
            var answer = await DisplayAlert("Delete?", "Are you sure you want to delete?", "Yes", "No");
            if (answer)
            {
                var button = sender as Button;
                var exer = button.BindingContext as Training;
                var vm = BindingContext as TrainingListViewModel;
                vm.DeleteCommand.Execute(exer);
            }
        }
    }
}