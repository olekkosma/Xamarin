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
        List<Exercise> tmp = new List<Exercise>();
        public ExerciseDatabase()
        {
            database = DependencyService.Get<ISQLiteHelper>().GetConnection();
            database.CreateTableAsync<Exercise>().Wait();
        }

        public void Seed()
        {
                database.InsertAsync(new Exercise { name = "Bench press" });
                database.InsertAsync(new Exercise { name = "Push up" });
                database.InsertAsync(new Exercise { name = "Pull up" });
                database.InsertAsync(new Exercise { name = "Inverted row" });
                database.InsertAsync(new Exercise { name = "Cable fly" });
                database.InsertAsync(new Exercise { name = "Bulgarian split squat" });
        }
        public void LoadSeedIfEmpty(int size)
        {
            if (size == 0)
            {
                Seed();
            }
        }
        public Task<List<Exercise>> GetAllExercisesAsync()
        {
            return database.Table<Exercise>().ToListAsync();
        }
        public Task<int> DeleteExerciseAsync(Exercise exer)
        {
                return database.DeleteAsync(exer);
        }

        public Task<int> SaveExerciseAsync(Exercise exer)
        {
            if (exer.Id != 0)
            {
                return database.UpdateAsync(exer);
            }
            else
            {
                return database.InsertAsync(exer);
            }
        }


        public void DeletellExercises(List<Exercise> tmp)
        {
            foreach(Exercise exer in tmp)
            {
                DeleteExerciseAsync(exer);
            }
        }


    }
}
