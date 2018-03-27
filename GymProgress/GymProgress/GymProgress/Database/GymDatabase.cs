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
            database.DropTableAsync<Training>();
            database.DropTableAsync<ExerciseInTraining>();
            database.DropTableAsync<Exercise>();
            database.CreateTableAsync<Exercise>();
            database.CreateTableAsync<ExerciseInTraining>();
            database.CreateTableAsync<Training>();
        }

        public void Seed()
        {
            Exercise exer = new Exercise { Name = "Testowane cwiczenie" };
            Exercise exer2 = new Exercise { Name = "Bench press" };
            database.InsertAsync(exer);
            database.InsertAsync(exer2);
            ExerciseInTraining exerInTrain = new ExerciseInTraining { Series = 5, Repetition = 5, Weight = 10 };
            ExerciseInTraining exerInTrain2 = new ExerciseInTraining { Series = 50, Repetition = 50, Weight = 100 };
            database.InsertAsync(exerInTrain);
            database.InsertAsync(exerInTrain2);
            exer.ExerInTraining = new List<ExerciseInTraining> { exerInTrain };

            exer2.ExerInTraining = new List<ExerciseInTraining> { exerInTrain2 };
            database.UpdateWithChildrenAsync(exer);
            database.UpdateWithChildrenAsync(exer2);
            Training training = new Training
            {
                Description = "Nie bylo latwo",
                Date = new DateTime(2017, 11, 12),
            };
            database.InsertAsync(training);
            training.ExercisesInTraining = new List<ExerciseInTraining> { exerInTrain,exerInTrain2 };
            exerInTrain.Training = training;
            exerInTrain2.Training = training;
            database.UpdateWithChildrenAsync(training);
            database.UpdateWithChildrenAsync(exerInTrain);
            database.UpdateWithChildrenAsync(exerInTrain2);

            database.InsertAsync(new Exercise { Name = "Push up" });
            database.InsertAsync(new Exercise { Name = "Pull up" });
            database.InsertAsync(new Exercise { Name = "Inverted row" });
        }
        public void LoadSeedIfEmpty(int size)
        {
            if (size == 0)
            {
                Seed();
            }
        }


        public async Task<Exercise> GetExerForExerInTrainingAsync(int id)
        {
            return await database.GetWithChildrenAsync<Exercise>(id);
        }
        public Task<List<Training>> GetAllTrainingsAsync()
        {
            return database.GetAllWithChildrenAsync<Training>();
        }

         public async Task<int> GetLastIdAsync()
        {
            return await database.ExecuteScalarAsync<int>("select last_insert_rowid()");
        }
        public Task<List<ExerciseInTraining>> GetAllExercisesInTrainingAsync()
        {
            return database.GetAllWithChildrenAsync<ExerciseInTraining>();
        }

        public async Task<List<ExerciseInTraining>> GetAllExercisesInCurrentTrainingAsync(int id)
        {
            return await database.GetAllWithChildrenAsync<ExerciseInTraining>(c => c.TrainingId == id);
        }

        public Task<List<Exercise>> GetAllExercisesAsync()
        {
            return database.GetAllWithChildrenAsync<Exercise>();
        }
        public async Task DeleteExerciseAsync(Exercise exer)
        {
            await database.DeleteAsync(exer, true);
        }

        public Task<int> DeleteExerciseInTrainingAsync(ExerciseInTraining exerInTraining)
        {
            return database.DeleteAsync(exerInTraining);
        }

        public Task<int> DeleteTrainingAsync(Training training)
        {
            return database.DeleteAsync(training);
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
