using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

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
        public void GetConnectionString_GeneralConnectionString()
        {
            //Arrange

            //Act
            string result = DatabaseFunctions.getConnectionString();

            //Assert
            Assert.That(result, Is.EqualTo(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\test_database.mdf;Integrated Security=True"));
        }


        [Test]
        public void InsertIngredient_()
        {
            //Arrange
            string newIngredient = "Zucker";
            RecipeService recipeService = new RecipeService();

            //Act
            recipeService.insertIngredient(newIngredient);

            //Assert
            //Assert.That(result, Is.EqualTo("x");
        }

        [Test]
        public void InsertRecipe_()
        {
            //Arrange
            Recipe newRecipe = new Recipe();
            string newIngredient = "Zucker";
            RecipeService recipeService = new RecipeService();

            //Act
            recipeService.insertRecipe(newRecipe);

            //Assert
            //Assert.That(result, Is.EqualTo("x");
        }
    }
}
