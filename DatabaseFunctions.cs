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

namespace Food_App
{
    public class DatabaseFunctions
    {


        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=.\\food-app_database.mdf;Integrated Security=True";
        //string connectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\georg\OneDrive\Desktop\Food-App\Food-App\food-app_database.mdf;Integrated Security=True";

    }
}