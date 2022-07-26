using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoodApp
{
    /// <summary>
    /// It is the main class of the application. It controls all interactions with recipes.
    /// </summary>
    public class RecipeService
    {
        /// <summary>
        /// Represents \ref Ingredient "ingredients" which were entered by an user.
        /// </summary>
        public List<Ingredient> enteredIngredients;
        /// <summary>
        /// Represents the recipes which's \ref Ingredient "ingredients" match the \ref enteredIngredients "entered ingredients".
        /// </summary>
        public List<Recipe> collectedRecipes;
        /// <summary>
        /// Represents the selected recipe by an user, when being shown the list of \ref  collecteRecipes "available recipes".
        /// </summary>
        public Recipe selectedRecipe;
        /// <summary>
        /// Is the connection to the database used for reading and writing data of recipes.
        /// </summary>
        public SqlConnection connection;
        /// <summary>
        /// Contains the connection string to the database.
        /// </summary>
        string connectionString = DatabaseFunctions.getConnectionString();


        public string sqlJoinFromString = @"FROM units INNER JOIN((recipes INNER JOIN (ingredients INNER JOIN recipe_connect ON ingredients.ID = recipe_connect.ingredient_ID) ON recipes.ID = recipe_connect.recipe_ID) INNER JOIN recipe_steps ON recipes.ID = recipe_steps.recipe_ID) ON units.ID = recipe_connect.unit_ID;";
        public string sqlSelectRecipeAndIngredient = "SELECT recipe_connect.recipe_ID, recipe_connect.ingredient_ID ";
        public string sqlSelectRestOfRecipe = "SELECT ingredients.ingredient, recipe_connect.amount, recipes.recipe_name, recipes.short_description, recipe_steps.step_description, units.unit ";
        public string sqlIngredientNames = "SELECT ingredients.ingredient ";

        /// <summary>
        /// Is the constructor for RecipeService.
        /// </summary>
        /// <remarks>
        /// Each RecipeService needs to contain list for the entered ingredients and the corresponding available recipes.
        /// </remarks>
        public RecipeService()
        {
            enteredIngredients = new List<Ingredient>();
            collectedRecipes = new List<Recipe>();
            //selectedRecipe = new Recipe();
        }

        /// <summary>
        /// Collects the IDs of all recipes in the database and their ingredients.
        /// </summary>
        /// <param name="allRecipes"></param>
        /// <returns>List Recipe</returns>
        public List<Recipe> GetAllRecipesIDs(List<Recipe> allRecipes)
        {
            allRecipes = new List<Recipe>();
            List<Recipe> sortedAllRecipes = new List<Recipe>();

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand((sqlSelectRecipeAndIngredient + sqlJoinFromString), cn))
            {
                cn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                int countR = 0;
                //read data from database into instance of Recipe
                while (reader.Read())
                {
                    Recipe recipe = new Recipe();
                    recipe.id = (int)reader["recipe_ID"];
                    allRecipes.Add(recipe);
                }
                cn.Close();

                //read data from database into ingredients list of each recipe
                List<Ingredient> tempIngredients = new List<Ingredient>();
                tempIngredients = GetIngredientIDs();
                foreach (Recipe recipe in allRecipes)
                {
                    recipe.ingredients = new List<Ingredient>();
                    foreach (Ingredient tempIngredient in tempIngredients)
                    {
                        Ingredient ingredient = new Ingredient();
                        ingredient.ID = tempIngredient.ID;
                        ingredient.recipeID = tempIngredient.recipeID;
                        if (ingredient.recipeID == recipe.id)
                        {
                            recipe.ingredients.Add(ingredient);
                        }
                    }
                    countR++;
                }

            }
            //since duplicate recipes with same id and same ingredients in list, duplicates need to be removed
            // allRecipes.Distinct() not working because type Recipe to complex
            for (int i = 0; i < allRecipes.Count; i++)
            {
                for (int j = 1; j < allRecipes.Count; j++)
                {
                    if (allRecipes[i].id == allRecipes[j].id)
                    {
                        allRecipes.Remove(allRecipes[j]);
                    }
                }
            }

            return allRecipes;

        }

        /// <summary>
        /// Searches for suitable recipes according to the entered ingredients.
        /// </summary>
        /// <remarks>
        /// Checks for each recipe if it contains only entered ingredients by comparing the list of entered ingredients with the list of recipes from the database.
        /// </remarks>
        /// <param name="enteredIngredients"></param>
        /// <returns>List Recipe</recipe></returns>
        public List<Recipe> SearchRecipesForIngredients(List<Ingredient> enteredIngredients)
        {
            List<Recipe> allRecipes = new List<Recipe>();
            allRecipes = GetAllRecipesIDs(allRecipes);
            List<Recipe> collectedRecipes = new List<Recipe>();
            // as soon as one recipe ingredient is not found in entered ingredients the bool will be set to false and the recipe won't be added to the collected recipes.
            foreach (Recipe recipeInstance in allRecipes)
            {
                bool onlyEnteredIngredientsInRecipe = false;
                foreach (Ingredient recipeIngredient in recipeInstance.ingredients)
                {
                    onlyEnteredIngredientsInRecipe = false;
                    for (int i = 0; i < enteredIngredients.Count; i++)
                    {
                        if (enteredIngredients[i].ID == recipeIngredient.ID)
                        {
                            onlyEnteredIngredientsInRecipe = true;
                            break;
                        }

                    }
                    if (onlyEnteredIngredientsInRecipe == false)
                    {
                        break;
                    }
                }
                if (onlyEnteredIngredientsInRecipe == true)
                {
                    collectedRecipes.Add(recipeInstance);
                }


            }
            return collectedRecipes;
        }

        /// <summary>
        /// Completes the data of recipes in the collected recipes list.
        /// </summary>
        /// <param name="selectedRecipes"></param>
        /// <returns>List Recipe</returns>
        public List<Recipe> CompleteDataInRecipes(List<Recipe> selectedRecipes)
        {
            //if the list of selected recipes does not contain any recipes throw exception
            try
            {
                if (selectedRecipes.Count == 0)
                {
                    throw new InvalidOperationException("No suitable Recipes Found!");
                }
            }
            catch (InvalidOperationException RecipeListIsEmpty)
            {
                return selectedRecipes;
            }
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlSelectRestOfRecipe + sqlJoinFromString, cn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                int i = 0;  //counter for selectedRecipes[]
                while (reader.Read() && (selectedRecipes.Count > i))
                {
                    selectedRecipes[i].name = (string)reader["recipe_name"];
                    selectedRecipes[i].description = (string)reader["short_description"];
                    int tempRecipeID = selectedRecipes[i].id;
                    selectedRecipes[i].steps = getStepsToRecipe(tempRecipeID);
                    selectedRecipes[i].ingredients = getIngredientsToRecipe(tempRecipeID);

                    i++;
                }
                cn.Close();
            }
            return selectedRecipes;
        }

        /// <summary>
        /// Collects all data related to a step from the database and collects them in a list.
        /// </summary>
        /// <param name="recipeID"></param>
        /// <returns>List Step</returns>
        public List<Step> getStepsToRecipe(int recipeID)
        {
            DataTable steps = new DataTable();
            List<Step> stepList = new List<Step>();
            SqlConnection connection;
            string connectionString = DatabaseFunctions.getConnectionString();

            //extract Ingredients
            string query = "SELECT step_number, step_description FROM recipe_steps WHERE recipe_ID = @recipeID";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                connection.Open();

                command.Parameters.Add("@recipeID", recipeID);
                adapter.Fill(steps);

                connection.Close();
            }

            foreach (DataRow row in steps.Rows)
            {
                Step step = new Step();
                step.number = Convert.ToInt32(row["step_number"]);
                step.description = (row["step_description"].ToString());

                stepList.Add(step);
            }

            return stepList;
        }

        /// <summary>
        /// Collects all data related to an ingredient from the database and collects them in a list.
        /// </summary>
        /// <param name="recipeID"></param>
        /// <returns>List Ingredient</returns>
        public List<Ingredient> getIngredientsToRecipe(int recipeID)
        {
            DataTable ingredients = new DataTable();
            List<Ingredient> ingredientList = new List<Ingredient>();
            SqlConnection connection;
            string connectionString = DatabaseFunctions.getConnectionString();

            //extract Ingredients
            string query = "SELECT ingredients.ingredient, recipe_connect.amount, units.unit FROM units INNER JOIN (ingredients INNER JOIN recipe_connect on ingredients.ID = recipe_connect.ingredient_ID) ON units.ID = recipe_connect.unit_ID WHERE recipe_ID = @recipeID";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                connection.Open();

                command.Parameters.Add("@recipeID", recipeID);
                adapter.Fill(ingredients);

                connection.Close();
            }

            foreach (DataRow row in ingredients.Rows)
            {
                Ingredient ingredient = new Ingredient();
                ingredient.name = (row["ingredient"].ToString());
                ingredient.amount = Convert.ToInt32(row["amount"]);
                ingredient.unit = (row["unit"].ToString());

                ingredientList.Add(ingredient);
            }

            return ingredientList;
        }

        /// <summary>
        /// Combines functions /ref SearchRecipesForIngredients and /ref CompleteDataInRecipes in one function.
        /// </summary>
        /// <param name="enteredIngredients"></param>
        /// <param name="collectedRecipes"></param>
        /// <returns>List Recipe</returns>
        public List<Recipe> SearchRecipes(List<Ingredient> enteredIngredients, List<Recipe> collectedRecipes)
        {
            collectedRecipes = SearchRecipesForIngredients(enteredIngredients);
            collectedRecipes = CompleteDataInRecipes(collectedRecipes);
            return collectedRecipes;
        }

        /// <summary>
        /// Collects the IDs of the ingredients in a list from the database.
        /// </summary>
        /// <returns>List Ingredient</returns>
        public List<Ingredient> GetIngredientIDs()
        {
            List<Ingredient> RecipeIngredients = new List<Ingredient>();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlSelectRecipeAndIngredient + sqlJoinFromString, cn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //write data from database into instance of Ingredient
                while (reader.Read())
                {
                    Ingredient ingredient = new Ingredient();
                    ingredient.ID = (int)reader["ingredient_ID"];
                    ingredient.recipeID = (int)reader["recipe_ID"];
                    RecipeIngredients.Add(ingredient);
                }
                cn.Close();
            }
            //removes duplicate ingredients
            //ingredientList.Distinct() not working because type Ingredient too complex
            for (int i = 0; i < RecipeIngredients.Count; i++)
            {
                for (int j = 1; j < RecipeIngredients.Count; j++)
                {
                    if ((RecipeIngredients[i].recipeID == RecipeIngredients[j].recipeID) && (RecipeIngredients[i].ID == RecipeIngredients[j].ID))
                    {
                        RecipeIngredients.Remove(RecipeIngredients[j]);
                    }
                }
            }
            return RecipeIngredients;
        }

        /// <summary>
        /// Collects all information for all ingredients from the database.
        /// </summary>
        /// <returns>DataTable</returns>
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
        /// <summary>
        /// Inserts added/new recipe into database.
        /// </summary>
        /// <param name="recipe"></param>
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

        /// <summary>
        /// Inserts added/new ingredient into database.
        /// </summary>
        /// <param name="newIngredient"></param>
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
