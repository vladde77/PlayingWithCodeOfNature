using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithCodeOfNature
{
    public class Population
    {
        public DNA[] populationSize;

        public Population(int size)
        {
            populationSize = new DNA[size];

            for (int i = 0; i < populationSize.Length; i++)
            {
                // Initializing each member of the population
                populationSize[i] = new DNA();
            }
        }

        public float Fitness(string target, DNA currentDna)
        {
            float score = 0;

            for (int i = 0; i < currentDna.genes.Length; i++)
            {
                if (currentDna.genes[i] == target[i])
                {
                    score++;
                }
            }

            float fitness = score / currentDna.genes.Length;

            return fitness;
        }


        public DNA[] createNewPopulation(List<DNA> matingpool)
        {
            Random rnd = new Random();
            DNA[] newPopulation = new DNA[matingpool.Count];

            for(int i = 0; i<matingpool.Count; i++)
            { 
                int a = rnd.Next(1, matingpool.Count());
                int b = rnd.Next(1, matingpool.Count());

                Debug.Print("Random Parent a " + a.ToString());
                Debug.Print("Random Parent b " + b.ToString());

                DNA parentA = matingpool[a];
                DNA parentB = matingpool[b];
                newPopulation[i] = parentA;

            }

            return newPopulation;


        }
    }
}
