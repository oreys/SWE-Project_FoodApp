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
    public class newRecipe
    {
        public string name;
        public string description;
        public List<string> steps;
        public List<ingredientNewRecipe> ingredients;
    }

    public class ingredientNewRecipe
    {
        public int ID;
        public int amount;
        public int unit_ID;

    }
    public partial class n{

        SqlConnection connection;
        string connectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\georg\OneDrive\Desktop\Food-App\Food-App\food-app_database.mdf;Integrated Security=True";

        private void insertRecipe(newRecipe recipe)
        {
            int newRecipeID;
            int stepNumber = 1;

            string query = "INSERT INTO Recipes (recipe_name, short_describtion) VALUES (@newRecipeName, @newDescribtion) select scope_identity()", cons;

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@newRecipeName", recipe.name);
                command.Parameters.AddWithValue("@newDescribtion", recipe.description);

                newRecipeID = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
            }

            /*query = "SELECT SCOPE_IDENTITY() FROM Recipes AS [SCOPE_IDENTITY];";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                newRecipeID = Convert.ToInt32(command.ExecuteScalar());
            }*/

            foreach (string step  in recipe.steps)
            {
                query = "INSERT INTO Recipes_Steps (Recipe_ID, Step_Number, Step_Discription) VALUES (@newRecipeID, @newStepNumber, @newStep)";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@newRecipeDI", newRecipeID);
                    command.Parameters.AddWithValue("@newStepNumber", stepNumber);
                    command.Parameters.AddWithValue("@newStep", step);

                    connection.Close();
                }

                stepNumber ++;
            }

            foreach (ingredientNewRecipe i  in recipe.ingredients)
            {
                query = "INSERT INTO Recipes_connect (Recipe_ID, Ingredient_ID, Amount, Unit_ID) VALUES (@newRecipeID, @ingredientID, @amount, @unitID)";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@newRecipeDI", newRecipeID);
                    command.Parameters.AddWithValue("@ingredientID", i.ID);
                    command.Parameters.AddWithValue("@amount", i.amount);
                    command.Parameters.AddWithValue("@unitID", i.unit_ID);

                    connection.Close();
                }
            }

        }
    }
}