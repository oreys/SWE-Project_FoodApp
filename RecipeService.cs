using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace FoodApp
{

    public class RecipeService
    {
        public List<Ingredient> enteredIngredients;
        public List<Recipe> collectedRecipes;
        public SqlConnection connection;
        string connectionString = DatabaseFunctions.getConnectionString();

        public string sqlJoinFromString = @"FROM units INNER JOIN((Recipes INNER JOIN (Ingredients INNER JOIN Recipe_connect 
                        ON Ingredients.ID = Recipe_connect.Ingredient_ID) ON Recipes.ID = Recipe_connect.Recipe_ID) 
                        INNER JOIN Recipe_steps ON Recipes.ID = Recipe_steps.Recipe_ID) ON Units.ID = Recipe_connect.Unit_ID;";
        public string sqlSelectRecipeAndIngredient = "SELECT Recipe_connect.Recipe_ID, Recipe_connect.Ingredient_ID ";
        public string sqlSelectRestOfRecipe = "SELECT ingredients.Ingredient, Recipe_connect.amount, Recipes.recipe_name, Recipes.short_description, Recipe_steps.step_description, Units.unit ";
        public string sqlIngredientNames = "SELECT ingredients.ingredient";
        public List<Recipe> GetAllRecipesIDs(List<Recipe> allRecipes)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlSelectRecipeAndIngredient + sqlJoinFromString, cn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Recipe recipe = new Recipe();
                    recipe.id = (int)reader["recipe_ID"];
                    recipe.ingredients = (List<Ingredient>)reader["ingredient_ID"]; //funktioniert das?
                    allRecipes.Add(recipe);
                }
                cn.Close();
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
            collectedRecipes = GetAllRecipesIDs(collectedRecipes);
            collectedRecipes = SearchRecipesForIngredients(enteredIngredients);
            collectedRecipes = CompleteDataInRecipes(collectedRecipes);
            return collectedRecipes;
        }

        public List<Ingredient> GetIngredientIDs(List<Ingredient> allIngredients)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))  //connection string name????
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

        public List<Ingredient> GetIngredientsFromDatabase()
        {
            List<Ingredient> availableIngredients = new List<Ingredient>();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlIngredientNames + sqlJoinFromString, cn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                int i = 0; //counter for availableIngredients
                while (reader.Read())
                {
                    availableIngredients[i].name = (string)reader["ingredient"];

                }
                cn.Close();

                return availableIngredients;
            }
        }

        public void insertRecipe(Recipe recipe)
        {
            //saves the ID of the new created Recipe for using it in the connectionTables
            int newRecipeID;

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

            foreach (Step step in recipe.steps)
            {
                query = "INSERT INTO Recipes_Steps (Recipe_ID, Step_Number, Step_Discription) VALUES (@newRecipeID, @newStepNumber, @newStep)";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@newRecipeDI", newRecipeID);
                    command.Parameters.AddWithValue("@newStepNumber", step.number);
                    command.Parameters.AddWithValue("@newStep", step.description);

                    connection.Close();
                }
            }

            foreach (Ingredient i in recipe.ingredients)
            {
                query = "INSERT INTO Recipes_connect (Recipe_ID, Ingredient_ID, Amount, Unit_ID) VALUES (@newRecipeID, @ingredientID, @amount, @unitID)";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@newRecipeDI", newRecipeID);
                    command.Parameters.AddWithValue("@ingredientID", i.ID);
                    command.Parameters.AddWithValue("@amount", i.amount);
                    command.Parameters.AddWithValue("@unitID", i.unitID);

                    connection.Close();
                }
            }
        }
        public void insertIngredient(string newIngredient)
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