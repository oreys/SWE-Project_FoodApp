using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodAppLibrary
{
    public class Ingredients: IEnumerable
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
