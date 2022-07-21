using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FoodApp
{
    public class DatabaseFunctions
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["FoodApp.Properties.Settings.food_app_databaseConnectionString"].ConnectionString;
        //private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\georg\OneDrive\Desktop\FoodApp\food-app_database.mdf;Integrated Security=True";

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