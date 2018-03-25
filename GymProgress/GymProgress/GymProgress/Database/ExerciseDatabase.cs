using GymProgress.Model;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
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
            database.CreateTableAsync<ExerciseInTraining>().Wait();

        }

        public void Seed()
        {
            Exercise exer = new Exercise { name = "Testowane cwiczenie" };
            database.InsertAsync(exer);
            ExerciseInTraining exerInTrain = new ExerciseInTraining { Series = 5, Repetition = 5, Weight = 10 };
            database.InsertAsync(exerInTrain);
            exer.ExerInTraining = new List<ExerciseInTraining> { exerInTrain };
            database.UpdateWithChildrenAsync(exer);
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

        public Task<List<ExerciseInTraining>> GetAllExercisesInTrainingsAsync()
        {
            //return database.Table<ExerciseInTraining>().ToListAsync();
            return database.GetAllWithChildrenAsync<ExerciseInTraining>();
        }

        public Task<List<Exercise>> GetAllExercisesAsync()
        {
            return database.Table<Exercise>().ToListAsync();
        }
        public Task<int> DeleteExerciseAsync(Exercise exer)
        {
            return database.DeleteAsync(exer);
        }

        public Task<int> DeleteExerciseInTrainingAsync(ExerciseInTraining exerInTraining)
        {
            return database.DeleteAsync(exerInTraining);
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
            foreach (Exercise exer in tmp)
            {
                DeleteExerciseAsync(exer);
            }
        }


    }
}
