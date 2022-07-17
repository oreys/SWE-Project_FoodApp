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
    public partial class m{

        SqlConnection connection;
        string connectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\georg\OneDrive\Desktop\Food-App\Food-App\food-app_database.mdf;Integrated Security=True";

        private void insertIngredient(string newIngredient)
        {
            string query = "INSERT INTO Ingredients (ingredient) VALUES (@newIngredient)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@newIngredient", newIngredient);

                connection.Close();
            }
        }
    }
}