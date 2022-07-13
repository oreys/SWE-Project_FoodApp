using System;
using System.Collections;
using System.Collections.Generic;


namespace FoodApp
{
    public class Ingredients : IEnumerable
    {
        public struct ingredient
        {
            string name;
            int id;
        }
        public List<ingredient> ingredients;


        public IEnumerator<T> GetEnumerator<T>()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
