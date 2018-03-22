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
	}
}