using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data.SqlClient;

namespace FoodApp.Tests
{
    [TestFixture]

    // For testing, please change in DatabaseFunction.cs the ConectionString
    // to the test_Database ConectionString and the InitializeDatabaseFile()
    // function to the InitializeTestDatabaseFile() function.
    // if it workend, you will see in the first Test

    internal class TestFoodApp
    {
        [Test]
        public void getConnectionString_GeneralConnectionString()
        {
            //Arrange

            //Act
            string result = DatabaseFunctions.getConnectionString();

            //Assert
            Assert.That(result, Is.EqualTo(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\test_database.mdf;Integrated Security=True"));
        }


        [Test]
        public void insertIngredient_OneIngredient_InsertSuccsess()
        {
            //Arrange
            string result;
            string newIngredient = "Zucker";
            RecipeService recipeService = new RecipeService();

            //Act
            recipeService.insertIngredient(newIngredient);

            //Assert
            string query = "SELECT TOP 1 ingredient FROM ingredients ORDER BY ID DESC";
            using (SqlConnection connection = new SqlConnection(DatabaseFunctions.getConnectionString()))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            { result = command.ExecuteScalar().ToString(); }

            Assert.That(result, Is.EqualTo(newIngredient));
        }

        [Test]
        public void GetAllRecipesIDs_EmptyList_ListWithAllRecipeIDsAndIngredients()
        {
            RecipeService recipeService = new RecipeService();

            //Arrange
            List<Recipe> result = new List<Recipe>();
            List<Recipe> check = new List<Recipe>(){new Recipe(){id = 1, ingredients = new List<Ingredient>(){new Ingredient(){ID = 1}, new Ingredient(){ID = 2}}}}; //according to dataset in test_database

            //Act
            result = recipeService.GetAllRecipesIDs(result);

            //Assert

            Assert.That(result, Is.EqualTo(check));
        }

        [Test]
        public void SearchRecipesForIngredients_IngredientsList_ListWithRecipeFittingToIngredients()
        {
            RecipeService recipeService = new RecipeService();

            //Arrange
            List<Ingredient> ingredients = new List<Ingredient>() { new Ingredient() { ID = 1 }, new Ingredient() { ID = 2 } };
            List<Recipe> result = new List<Recipe>();
            List<Recipe> check = new List<Recipe>() { new Recipe() { id = 1, ingredients = new List<Ingredient>() { new Ingredient() { ID = 1 }, new Ingredient() { ID = 2 } } } }; //according to dataset in test_database

            //Act
            result = recipeService.SearchRecipesForIngredients(ingredients);

            //Assert

            Assert.That(result, Is.EqualTo(check));
        }

        [Test]
        public void CompleteDataInRecipes_EmptyList_EmptyList()
        {
            RecipeService recipeService = new RecipeService();

            //Arrange
            List<Recipe> result = new List<Recipe>();
            List<Recipe> check = new List<Recipe>();
            //Act
            result = recipeService.CompleteDataInRecipes(result);

            //Assert

            Assert.That(result, Is.EqualTo(check));
        }

        [Test]
        public void CompleteDataInRecipes_ListWithOneRecipe_ListWithRecipeFilledWithData()
        {
            RecipeService recipeService = new RecipeService();

            //Arrange
            List<Recipe> result = new List<Recipe>() { new Recipe() { id = 1, ingredients = new List<Ingredient>() { new Ingredient() { ID = 1 }, new Ingredient() { ID = 2 } } } };
            List<Recipe> check = new List<Recipe>() { new Recipe() {
                id = 1,
                name = "Salzsuppe",
                description = "einfach, schnell, aber nicht lecker oder narhaft",
                steps = new List<Step>() {
                    new Step() { number = 1, description = "Salz und Wasser in einen Topf geben" },
                    new Step() { number = 2, description = "gut auf kochen" }
                },
                ingredients = new List<Ingredient>() {
                    new Ingredient() { name = "Wasser", amount = 1, unit = "L" },
                    new Ingredient() { name = "Salz", amount = 10, unit = "g" }
                }
            } }; //according to dataset in test_database

            //Act
            result = recipeService.CompleteDataInRecipes(result);

            //Assert

            Assert.That(result, Is.EqualTo(check));
        }

        [Test]
        public void getStepsToRecipe_RecipeID_ListOfStepsForRecipe()
        {
            RecipeService recipeService = new RecipeService();

            //Arrange
            int ID = 1;
            List<Step> result = new List<Step>();
            List<Step> check = new List<Step>() {
                new Step() { number = 1, description = "Salz und Wasser in einen Topf geben" },
                new Step() { number = 2, description = "gut auf kochen" }
                }; //according to dataset in test_database

            //Act
            result = recipeService.getStepsToRecipe(ID);

            //Assert

            Assert.That(result, Is.EqualTo(check));
        }

        [Test]
        public void getIngredientsToRecipe_RecipeID_ListOfIngredientsForRecipe()
        {
            RecipeService recipeService = new RecipeService();

            //Arrange
            int ID = 1;
            List<Ingredient> result = new List<Ingredient>();
            List<Ingredient> check  = new List<Ingredient>() {
                new Ingredient() { name = "Wasser", amount = 1, unit = "L" },
                new Ingredient() { name = "Salz", amount = 10, unit = "g" }
            }; //according to dataset in test_database

            //Act
            result = recipeService.getIngredientsToRecipe(ID);

            //Assert

            Assert.That(result, Is.EqualTo(check));
        }
    }
}
