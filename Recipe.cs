using System.Collections.Generic;

namespace FoodApp
{
    /// <summary>
    /// This class represents the basic structure of a recipe.
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Is a unique identifier for each recipe.
        /// </summary>
        public int id;
        /// <summary>
        /// Represents the name of a recipe.
        /// </summary>
        public string name;
        /// <summary>
        /// Represents a short description for a recipe.
        /// </summary>
        public string description;
        /// <summary>
        /// Represents list of steps of a recipe.
        /// </summary>
        public List<Step> steps;
        /// Represents list of \ref Ingredient "ingredients" of a recipe.
        public List<Ingredient> ingredients;


    }
}