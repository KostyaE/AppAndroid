using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppWeather2
{
    public class FriendRepository
    {
        SQLiteConnection database;
        public FriendRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<City>();
        }
        public IEnumerable<City> GetItems()
        {
            return (from i in database.Table<City>() select i).ToList();

        }
        public City GetItem(int id)
        {
            return database.Get<City>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<City>(id);
        }
        public int SaveItem(City item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
