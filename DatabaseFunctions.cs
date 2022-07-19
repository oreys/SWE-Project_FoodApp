using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Resources;
using System.IO;

namespace FoodApp
{
    public class DatabaseFunctions
    {
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=.\\food-app_database.mdf;Integrated Security=True";
          
        //connect to database
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

        public static string getConnectionString()
        {
            return connectionString;
        }
    }
}