﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithCodeOfNature
{
    public class Population
    {
        public DNA[] population;
        public string targetPhrase;
        public float mutationRate;
        private static Random rnd = new Random();


        public Population(int size, int genesLength, string targetPhrase, float mutationRate)
        {
            population = new DNA[size];
            this.targetPhrase = targetPhrase;
            this.mutationRate = mutationRate;

            for (int i = 0; i < population.Length; i++)
            {
                // Initializing each member of the population
                population[i] = new DNA(genesLength);
            }
        }

        public float Fitness(DNA currentDna)
        {
            float score = 0;

            for (int i = 0; i < currentDna.genes.Length; i++)
            {
                if (currentDna.genes[i] == this.targetPhrase[i])
                {
                    score++;
                }
            }

            float fitness = score / currentDna.genes.Length;

            return fitness;
        }


        public DNA[] createNewPopulation(List<DNA> matingpool)
        {
            //Random rnd = new Random();
            DNA[] newPopulation = new DNA[population.Length];

            for(int i = 0; i< population.Length; i++)
            { 
                int a = rnd.Next(1, matingpool.Count());
                int b = rnd.Next(1, matingpool.Count());

                DNA parentA = matingpool[a];
                DNA parentB = matingpool[b];

                DNA newChild = crossOver(parentA, parentB);
                Debug.Print(new string(newChild.genes));

                newChild = mutate(newChild);

                //Debug.Print(new string(newChild.genes));

                newPopulation[i] = newChild;

            }

            return newPopulation;

        }

        private DNA crossOver(DNA parentA, DNA parentB)
        {
            //Random rnd = new Random();
            DNA childDna = new DNA(parentA.genes.Length);

            int midPoint = rnd.Next(parentA.genes.Length);

            for (int i = 0; i < parentA.genes.Length; i++)
            {
                if (i > midPoint)
                    childDna.genes[i] = parentA.genes[i];
                else
                    childDna.genes[i] = parentB.genes[i];
            }
            return childDna;

        }

        private DNA mutate(DNA dnaToMutate)
        {
            //Random rnd = new Random();

            for (int i = 0; i < dnaToMutate.genes.Length; i++)
            {
                if (rnd.NextDouble() < mutationRate)
                {
                    dnaToMutate.genes[i] = (char)rnd.Next(32, 128);
                }
            }

            return dnaToMutate;
        }
    }
}
