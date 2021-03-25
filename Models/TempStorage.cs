using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{

    //This TempStorage class is no longer used w/ the sqlite implementation
    public class TempStorage
    {
        private static List<MovieItem> inputs = new List<MovieItem>();

        public static IEnumerable<MovieItem> Inputs => inputs;

        public static void AddInput(MovieItem input)
        {
            inputs.Add(input);
        }
    }
}
