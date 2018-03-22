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
	public partial class EmployeeListPage : ContentPage
	{
        public EmployeeListPage()
        {
            
            InitializeComponent();
            this.Title = "olo277xD";

           
          
            var toolbarItem = new ToolbarItem
            {
                Text = "+"
            };
            toolbarItem.Clicked += async (sender, e) =>
            {
                
                await Navigation.PushAsync(new EmployeePage() { BindingContext = new Emplyee() });
            };
            ToolbarItems.Add(toolbarItem);
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
           

            EmployeeListView.ItemsSource = await App.Database.GetEmplyeesAsync();
           
        }
            async void Employee_ItemSelected (object sender,Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new EmployeePage() { BindingContext = e.SelectedItem as Emplyee});

            }
        }
    }
}