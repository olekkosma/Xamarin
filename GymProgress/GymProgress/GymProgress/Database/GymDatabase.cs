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
    public class GymDatabase
    {
        readonly SQLiteAsyncConnection database;
        public GymDatabase()
        {
            database = DependencyService.Get<ISQLiteHelper>().GetConnection();
            database.CreateTableAsync<Exercise>();
            database.CreateTableAsync<ExerciseInTraining>();
            database.CreateTableAsync<Training>();
        }

        public void Seed()
        {
            Exercise exer = new Exercise { Name = "Testowane cwiczenie" };
            database.InsertAsync(exer);
            ExerciseInTraining exerInTrain = new ExerciseInTraining { Series = 5, Repetition = 5, Weight = 10 };
            database.InsertAsync(exerInTrain);
            exer.ExerInTraining = new List<ExerciseInTraining> { exerInTrain };
            database.UpdateWithChildrenAsync(exer);
            database.InsertAsync(new Exercise { Name = "Bench press" });
            database.InsertAsync(new Exercise { Name = "Push up" });
            database.InsertAsync(new Exercise { Name = "Pull up" });
            database.InsertAsync(new Exercise { Name = "Inverted row" });
            database.InsertAsync(new Exercise { Name = "Cable fly" });
            database.InsertAsync(new Exercise { Name = "Bulgarian split squat" });
        }
        public void LoadSeedIfEmpty(int size)
        {
            if (size == 0)
            {
                Seed();
            }
        }

        public Task<List<ExerciseInTraining>> GetAllExercisesInTrainingAsync()
        {
            return database.GetAllWithChildrenAsync<ExerciseInTraining>();
        }

        public Task<List<Exercise>> GetAllExercisesAsync()
        {
            return database.GetAllWithChildrenAsync<Exercise>();
        }
        public Task<int> DeleteExerciseAsync(Exercise exer)
        {
            return database.DeleteAsync(exer);
        }

        public Task<int> DeleteExerciseInTrainingAsync(ExerciseInTraining exerInTraining)
        {
            return database.DeleteAsync(exerInTraining);
        }


        public Task SaveExerciseAsync(Exercise exer)
        {
            if (exer.Id != 0)
            {
                return database.UpdateWithChildrenAsync(exer);
            }
            else
            {
                return database.InsertWithChildrenAsync(exer);
            }
        }

        public Task SaveExerciseInTrainingAsync(ExerciseInTraining exerInTraining)
        {
            if (exerInTraining.Id != 0)
            {
                return database.UpdateWithChildrenAsync(exerInTraining);
            }
            else
            {
                return database.InsertWithChildrenAsync(exerInTraining);
            }
        }


        public void DeletellExercises(List<Exercise> tmp)
        {
            foreach (Exercise exer in tmp)
            {
                DeleteExerciseAsync(exer);
            }
        }

        public void DeleteAllExercisesInTraining(List<ExerciseInTraining> tmp)
        {
            foreach (ExerciseInTraining exer in tmp)
            {
                DeleteExerciseInTrainingAsync(exer);
            }
        }

        public Task SaveTrainingAsync(Training training)
        {
            if (training.Id != 0)
            {
                return database.UpdateWithChildrenAsync(training);
            }
            else
            {
                return database.InsertWithChildrenAsync(training);
            }
        }


    }
}
