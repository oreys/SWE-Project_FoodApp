namespace FoodApp
{
    /// <summary>
    /// This class represents the basic structure of an ingredient and its properties.
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Is a unique identifier for each ingredient.
        /// </summary>
        public int ID;
        /// <summary>
        /// Represents the name of a recipe.
        /// </summary>
        public string name;
        /// <summary>
        /// Represents the amount of an ingredient needed for a dish.
        /// </summary>
        public int amount;
        /// <summary>
        /// Is a unique identifier for each unit. 
        /// </summary>
        /// <remarks>
        /// Is used in \ref Ingredient "ingredient" to connect the correct unit with an ingredient.
        /// </remarks>
        public int unitID;
        /// <summary>
        /// Represents the unit in which an \ref Ingredient "ingredient" is measured
        /// </summary>
        public string unit;
        /// <summary>
        /// Is a unique identifier for an instance of an \ref Ingredient "ingredient" to be referred to a recipe.
        /// </summary>
        public int recipeID;
    }
}
