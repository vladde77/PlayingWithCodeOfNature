using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithCodeOfNature
{
    public class Population
    {
        public DNA[] population = new DNA[100];


        public Population()
        {
            for (int i = 0; i < population.Length; i++)
            {
                // Initializing each member of the population
                population[i] = new DNA();
            }
        }
    }
}
