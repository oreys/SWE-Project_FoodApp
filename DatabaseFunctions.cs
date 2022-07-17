namespace FoodApp
{
    public class DatabaseFunctions
    {


        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=.\\food-app_database.mdf;Integrated Security=True";
        //string connectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\georg\OneDrive\Desktop\Food-App\Food-App\food-app_database.mdf;Integrated Security=True";
        //connect to database

        public void InitializeDatabaseFile()
        {
            string path = ".\\food-app_database.mdf";
            bool databaseFound = File.Exists(path);

            //prüfe ob Datenbank vorhanden
            //wenn vorhanden return
            if (databaseFound)
            {
                return;
            }
            //nicht: aus resources: Datenbank
            else
            {
                var database = FoodAppLibrary.Properties.Resources.food_app_database;
                var fileStream = File.Create(path);
                fileStream.Write(database, 0, database.Length);
                fileStream.Close();
            }


        }

    }
}