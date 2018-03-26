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
		public AddExericeView ()
		{
			InitializeComponent ();
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


    }
}