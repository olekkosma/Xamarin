using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Gym
{
	public partial class App : Application
	{
        static EmployeeDatabase database;
		public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new EmployeeListPage());
		}

        public static EmployeeDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new EmployeeDatabase();
                }
                return database;
            }
        }


		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
