using GymProgress.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GymProgress.Database
{
    class ExerciseDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ExerciseDatabase()
        {
            database = DependencyService.Get<ISQLiteHelper>().GetConnection();
            database.CreateTableAsync<Exercise>().Wait();
        }

        public Task<List<Exercise>> GetAllExercisesAsync()
        {
            database.InsertAsync(new Exercise { name = "Bench press" });
            database.InsertAsync(new Exercise { name = "Push up" });
            database.InsertAsync(new Exercise { name = "Pull up" });

            return database.Table<Exercise>().ToListAsync();
        }
    }
}
