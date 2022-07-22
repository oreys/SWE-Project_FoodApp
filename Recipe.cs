using System.Collections.Generic;

namespace FoodApp
{
    public class Recipe
    {
        public int id;
        public string name;
        public string description;
        public List<Step> steps;
        public List<Ingredient> ingredients;


    }
}