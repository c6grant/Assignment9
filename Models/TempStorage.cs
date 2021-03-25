using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class TempStorage
    {
        private static List<InputResponse> inputs = new List<InputResponse>();

        public static IEnumerable<InputResponse> Inputs => inputs;

        public static void AddInput(InputResponse input)
        {
            inputs.Add(input);
        }
    }
}
