using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Gym.Models
{
    public class EmployeeDatabase
    {
        readonly SQLiteAsyncConnection database;

        public EmployeeDatabase()
        {
            database = DependencyService.Get<ILocalFileHelper>().GetConnection();
            database.CreateTableAsync<Emplyee>().Wait();
        }
        public Task<List<Emplyee>> GetEmplyeesAsync()
        {
            return database.Table<Emplyee>().ToListAsync();
        }
        public Task<Emplyee> GetEmployeeAsync(int id)
        {
            
            return database.Table<Emplyee>().Where(i => i.EmpId == 2).FirstOrDefaultAsync();
        }
        public Task<int> SaveEmployeeAsync(Emplyee emplyee)
        {
            if (emplyee.EmpId != 0)
            {
                return database.UpdateAsync(emplyee);
            }
            else
            {
                return database.InsertAsync(emplyee);
            }
        }
        public Task<int> DeleteEmployeeAsync(Emplyee employee)
        {
            return database.DeleteAsync(employee);
        }

    }
}
