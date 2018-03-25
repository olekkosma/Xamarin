using GymProgress2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GymProgress2
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            InitializeComponent();
            ExerciseDatabase database = new ExerciseDatabase();
            database.Seed();
        }
	}
}
