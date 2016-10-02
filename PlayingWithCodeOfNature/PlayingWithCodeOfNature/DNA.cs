using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithCodeOfNature
{
    public class DNA
    {
        public char[] genes;
        private static Random rnd = new Random();

        public DNA(int genesLength)
        {

            genes = new char[genesLength];

            for (int i = 0; i < genes.Length; i++)
            {
                // Picking randomly from a range of characters
                // with ASCII values between 32 and 128.
                // For more about ASCII:
                // http://en.wikipedia.org/wiki/ASCII[ASCII]

                genes[i] = (char)rnd.Next(32, 128);
            }
        }
    }
}
