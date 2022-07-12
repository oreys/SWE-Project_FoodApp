using System.Collections.Generic;

namespace FoodAppLibrary
{
    public class Recipe
    {
        struct recipe
        {
            public string name;
            public string description;
            public List<string> steps;

            public List<Ingredients.ingredient> ingredients;
        }
        List<recipe> allRecipes;
        List<recipe> collectedRecipes;
        public void SearchRecipesForIngredients(List<Ingredients.ingredient> enteredIngredients)
        {
            bool onlyEnteredIngredientsInRecipe = true;
            foreach (recipe recipe in allRecipes)
            {
                foreach(Ingredients.ingredient recipeIngredient in recipe.ingredients)
                {
                    if(!(enteredIngredients.Contains(recipeIngredient)))
                    {
                        onlyEnteredIngredientsInRecipe = false;
                    }
                }
                if (onlyEnteredIngredientsInRecipe == true)
                {
                    collectedRecipes.Add(recipe);
                }
            }
        }
        public void CreateNewRecipe() { }
        public void addNewIngredient() { }
    }
}