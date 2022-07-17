namespace FoodApp
{
    public class Recipe
    {
        public int id;
        public string name;
        public string description;
        public List<Step> steps;
        public List<Ingredient> ingredients;

        public void StepsListToString(List<string> list)
        {
            string collectedSteps = "";
            int counter = 0;//counter for list
            int number = 1;
            foreach (Step step in steps)//check if still correct
            {
                collectedSteps += number.ToString() + ". " + list[counter];
                number++;
                counter++;
            }
        }

        /* public void IngredientsListToString(List<Ingredient> list)//unfinished
         {
             string collectedIngredients = "";
             int counter = 0;//counter for list
             int number = 1;
             foreach (Ingredient ingredient in collectedIngredients)
             {
                 //collectedIngredients += list[counter];
                 number++;
                 counter++;
             }
         }*/
    }


}
