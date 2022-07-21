using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace FoodApp
{

    public class RecipeService
    {
        public List<Ingredient> enteredIngredients;
        public List<Recipe> collectedRecipes;
        public Recipe selectedRecipe;
        public SqlConnection connection;
        string connectionString = DatabaseFunctions.getConnectionString();

        public string sqlJoinFromString = @"FROM units INNER JOIN((recipes INNER JOIN (ingredients INNER JOIN recipe_connect ON ingredients.ID = recipe_connect.ingredient_ID) ON recipes.ID = recipe_connect.recipe_ID) INNER JOIN recipe_steps ON recipes.ID = recipe_steps.recipe_ID) ON units.ID = recipe_connect.unit_ID;";
        public string sqlSelectRecipeAndIngredient = "SELECT recipe_connect.recipe_ID, recipe_connect.ingredient_ID ";
        public string sqlSelectRestOfRecipe = "SELECT ingredients.ingredient, recipe_connect.amount, recipes.recipe_name, recipes.short_description, recipe_steps.step_description, units.unit ";
        public string sqlIngredientNames = "SELECT ingredients.ingredient ";

        public List<Recipe> GetAllRecipesIDs(List<Recipe> allRecipes)
        {
            /*DataTable ingredientsTable = new DataTable();
            SqlConnection connection;
            string connectionString = DatabaseFunctions.getConnectionString();

            //extract Ingredients
            string queryI = "SELECT * FROM ingredients";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryI, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(ingredientsTable);
            }
            return ingredientsTable;*/


            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand((sqlSelectRecipeAndIngredient + sqlJoinFromString), cn))
            {
                cn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                int countR = 0;
                int countI = 0;
                while (reader.Read())
                {
                    Recipe recipe = new Recipe();
                    recipe.id = (int)reader["recipe_ID"];
                    //recipe.ingredients = GetIngredientIDs(allRecipes[countR].ingredients);
                    //(List<Ingredient>)reader["ingredient_ID"]; 
                    allRecipes.Add(recipe);

                }
                cn.Close();
                foreach (Recipe recipe in allRecipes)
                {
                    List<Ingredient> tempIngredients = GetIngredientIDs();

                    foreach (Ingredient tempIngredient in tempIngredients)
                    {
                        Ingredient ingredient = new Ingredient();
                        ingredient.ID = tempIngredients[countI].ID;
                        allRecipes[countR].ingredients.Add(ingredient);//throws exception: igredient  = null reference
                        countI++;
                    }
                    countR++;
                }

            }
            return allRecipes;

        }
        public List<Recipe> SearchRecipesForIngredients(List<Ingredient> enteredIngredients)
        {
            List<Recipe> allRecipes = new List<Recipe>();
            allRecipes = GetAllRecipesIDs(allRecipes);
            List<Recipe> collectedRecipes = new List<Recipe>();
            bool onlyEnteredIngredientsInRecipe = true;
            int i = 0;  //counter for allRecipes[]
            foreach (Recipe recipeInstance in allRecipes)
            {
                foreach (Ingredient recipeIngredient in allRecipes[i].ingredients)
                {
                    if (!(enteredIngredients.Contains(recipeIngredient)))
                    {
                        onlyEnteredIngredientsInRecipe = false;
                    }
                }
                if (onlyEnteredIngredientsInRecipe == true)
                {
                    collectedRecipes.Add(recipeInstance);
                }
                i++;

            }
            return collectedRecipes;
        }

        public List<Recipe> CompleteDataInRecipes(List<Recipe> selectedRecipes)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlSelectRestOfRecipe + sqlJoinFromString, cn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                int i = 0;  //counter for selectedRecipes[]
                while (reader.Read())
                {
                    selectedRecipes[i].name = (string)reader["recipe_name"];
                    selectedRecipes[i].description = (string)reader["short_description"];
                    for (int j = 0; j < selectedRecipes[j].steps.Count; j++)
                    {
                        selectedRecipes[i].steps[j].number = (int)reader["step_number"];
                        selectedRecipes[i].steps[j].description = (string)reader["step_description"];
                    }
                    for (int j = 0; j < selectedRecipes[j].ingredients.Count; j++)
                    {
                        selectedRecipes[i].ingredients[j].name = (string)reader["ingredient"];
                        selectedRecipes[i].ingredients[j].amount = (int)reader["amount"];
                        selectedRecipes[i].ingredients[j].unit = (string)reader["unit"];
                    }

                    i++;
                }
                cn.Close();
            }
            return selectedRecipes;
        }

        public List<Recipe> SearchRecipes(List<Ingredient> enteredIngredients, List<Recipe> collectedRecipes)
        {
            //List<Recipe> allRecipes = new List<Recipe>();
            //allRecipes = GetAllRecipesIDs(allRecipes);
            collectedRecipes = SearchRecipesForIngredients(enteredIngredients);
            collectedRecipes = CompleteDataInRecipes(collectedRecipes);
            return collectedRecipes;
        }

        public List<Ingredient> GetIngredientIDs()
        {
            List<Ingredient> allIngredients = new List<Ingredient>();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlSelectRecipeAndIngredient + sqlJoinFromString, cn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Ingredient ingredient = new Ingredient();
                    ingredient.ID = (int)reader["ingredient_ID"];
                    allIngredients.Add(ingredient);
                }
                cn.Close();
            }
            return allIngredients;
        }

        public DataTable GetIngredientsFromDatabase()
        {
            DataTable ingredientsTable = new DataTable();
            SqlConnection connection;
            string connectionString = DatabaseFunctions.getConnectionString();

            //extract Ingredients
            string queryI = "SELECT * FROM ingredients";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryI, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(ingredientsTable);
            }

            return ingredientsTable;
        }

        public void insertRecipe(Recipe recipe)
        {
            //saves the ID of the new created Recipe for using it in the connectionTables
            int newRecipeID;

            string query = "INSERT INTO Recipes (recipe_name, short_describtion) VALUES (@newRecipeName, @newDescribtion) select scope_identity()", cons;
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
                try
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@newRecipeName", recipe.name);
                    command.Parameters.AddWithValue("@newDescribtion", recipe.description);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Records Inserted Successfully");
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    newRecipeID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                }

            foreach (Step step in recipe.steps)
            {
                query = "INSERT INTO Recipes_Steps (Recipe_ID, Step_Number, Step_Discription) VALUES (@newRecipeID, @newStepNumber, @newStep)";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                    try
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@newRecipeDI", newRecipeID);
                        command.Parameters.AddWithValue("@newStepNumber", step.number);
                        command.Parameters.AddWithValue("@newStep", step.description);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Records Inserted Successfully");
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show("Error Generated. Details: " + e.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }
            }

            foreach (Ingredient i in recipe.ingredients)
            {
                query = "INSERT INTO Recipes_connect (Recipe_ID, Ingredient_ID, Amount, Unit_ID) VALUES (@newRecipeID, @ingredientID, @amount, @unitID)";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                    try
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@newRecipeDI", newRecipeID);
                        command.Parameters.AddWithValue("@ingredientID", i.ID);
                        command.Parameters.AddWithValue("@amount", i.amount);
                        command.Parameters.AddWithValue("@unitID", i.unitID);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Records Inserted Successfully");
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show("Error Generated. Details: " + e.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }
            }
        }
        public void insertIngredient(string newIngredient)
        {
            string query = "INSERT INTO ingredients (ingredient) VALUES (@newIngredient)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
                try
                {
                    connection.Open();
                    if (!(string.IsNullOrEmpty(newIngredient)))
                    {
                        command.Parameters.AddWithValue("@newIngredient", newIngredient);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Records Inserted Successfully");
                    }
                    else
                    {
                        MessageBox.Show("no Ingredient to insert");
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    connection.Close();
                }
        }
    }
}