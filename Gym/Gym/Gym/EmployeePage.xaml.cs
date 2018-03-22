using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gym
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployeePage : ContentPage
	{
		public EmployeePage ()
		{
			InitializeComponent ();
            
        }

        async void  Save_Clicked(object sender,System.EventArgs e)
        {
            var personItem = (Emplyee)BindingContext;
            await App.Database.SaveEmployeeAsync(personItem);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}