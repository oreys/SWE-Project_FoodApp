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

        public RecipeService()
        {
            enteredIngredients = new List<Ingredient>();
            collectedRecipes = new List<Recipe>();
            //selectedRecipe = new Recipe();
        }

        public List<Recipe> GetAllRecipesIDs(List<Recipe> allRecipes)
        {
            allRecipes = new List<Recipe>();
            List<Recipe> sortedAllRecipes = new List<Recipe>();
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

            /*for (int i = 0; i < allRecipes.Count; i++)
            {
                for (int j = 1; j < allRecipes.Count; j++)
                {
                    if (allRecipes[i].id == allRecipes[j].id)
                    {
                        //for (int k = 0; k < allRecipes[j].ingredients.Count; k++)
                        //{
                        allRecipes[i].ingredients.Add(allRecipes[j].ingredients[0]);
                        allRecipes.Remove(allRecipes[j]);
                        // }

                    }

                }
            }*/

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
        public List<Recipe> SearchRecipesForIngredients(List<Ingredient> enteredIngredients)
        {
            List<Recipe> allRecipes = new List<Recipe>();
            allRecipes = GetAllRecipesIDs(allRecipes);
            List<Recipe> collectedRecipes = new List<Recipe>();

            //bool onlyEnteredIngredientsInRecipe;
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

        public List<Recipe> CompleteDataInRecipes(List<Recipe> selectedRecipes)
        {
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
                    selectedRecipes[i].steps = new List<Step>();
                    /*for (int j = 0; j < selectedRecipes[j].steps.Count; j++)
                    {
                        selectedRecipes[i].steps[j].number = (int)reader["step_number"];
                        selectedRecipes[i].steps[j].description = (string)reader["step_describtion"];
                    }
                    selectedRecipes[i].ingredients = new List<Ingredient>();
                    for (int j = 0; j < selectedRecipes[j].ingredients.Count; j++)
                    {
                        selectedRecipes[i].ingredients[j].name = (string)reader["ingredient"];
                        selectedRecipes[i].ingredients[j].amount = (int)reader["amount"];
                        selectedRecipes[i].ingredients[j].unit = (string)reader["unit"];
                    }*/

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
            List<Ingredient> RecipeIngredients = new List<Ingredient>();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlSelectRecipeAndIngredient + sqlJoinFromString, cn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Ingredient ingredient = new Ingredient();
                    ingredient.ID = (int)reader["ingredient_ID"];
                    ingredient.recipeID = (int)reader["recipe_ID"];
                    RecipeIngredients.Add(ingredient);
                }
                cn.Close();
            }
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