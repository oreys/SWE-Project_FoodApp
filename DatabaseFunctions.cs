using System.Configuration;
using System.IO;

namespace FoodApp
{
    /// <summary>
    /// Is the class for securing a connection to the database.
    /// </summary>
    public class DatabaseFunctions
    {
        /// <summary>
        /// Contains the connection string for establishing a connection to the database.
        /// </summary>
        private static string connectionString = ConfigurationManager.ConnectionStrings["FoodApp.Properties.Settings.food_app_databaseConnectionString"].ConnectionString;


        /// <summary>
        /// Initializes the database file.
        /// </summary>
        public void InitializeDatabaseFile()
        {
            string path = ".\\food-app_database.mdf";
            bool databaseFound = File.Exists(path);

            //check if database exists
            //if existing, only return
            if (databaseFound)
            {
                return;
            }
            //if not: take the database from resources
            else
            {
                var database = FoodApp.Properties.Resources.food_app_database;
                var fileStream = File.Create(path);
                fileStream.Write(database, 0, database.Length);
                fileStream.Close();
            }
        }

        /// <summary>
        /// Returns the connection string to the caller of the function.
        /// </summary>
        /// <returns></returns>
        public static string getConnectionString()
        {
            return connectionString;
        }
    }
}
