using System.Collections.Generic;

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

    
}