using System.IO;
using AppWeather2.Droid;


[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Android))]
namespace AppWeather2.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}