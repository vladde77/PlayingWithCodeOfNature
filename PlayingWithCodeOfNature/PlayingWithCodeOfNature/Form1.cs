using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayingWithCodeOfNature
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int populationSize = 1000;
            string targetPhrase = "to be or not to be that is the question";
            float mutationRate = 0.01f;

            Population population = new Population(populationSize, targetPhrase.Length, targetPhrase, mutationRate);

            int currentDnaFitness = 0;
            int currentGeneration = 0;
            var evolved = evolvePopulation(currentDnaFitness, ref population, ref currentGeneration);

        }

        //private int evolvePopulation(Population populationToEvolve, ref int currentDnaFitness)
        static int evolvePopulation(int currentDnaFitness, ref Population populationToEvolve, ref int currentGeneration)
        {


            var matingpool = new List<DNA>();

            var totalFitness = 0f;
            var collection = new Dictionary<DNA, float>();

            foreach (DNA dna in populationToEvolve.population)
            {
                var currentDnaFitnessAsFloat = populationToEvolve.Fitness(dna);
                totalFitness = totalFitness + currentDnaFitnessAsFloat;
                collection.Add(dna, currentDnaFitnessAsFloat);

                //Debug.Print("Current DNA Fitness as currentDnaFitness : " + currentDnaFitnessAsFloat.ToString());

                //currentDnaFitness = (int)(currentDnaFitnessAsFloat * 100);


                //for (int j = 0; j < currentDnaFitness; j++)
                //{
                //    matingpool.Add(dna);
                //}
            }
            //Debug.Print("Matingpool size : " + matingpool.Count.ToString());


            foreach(KeyValuePair<DNA, float> entry in collection)
            {
                if (entry.Value >= 1)
                {
                    Debug.Print(new string(entry.Key.genes));
                    return 1;
                }

                var procentage = entry.Value / totalFitness;
                //Debug.Print("Current DNA Fitness as currentDnaFitness : " + procentage.ToString());

                currentDnaFitness = (int)(procentage * populationToEvolve.population.Length);
                
                for (int j = 0; j < currentDnaFitness; j++)
                {
                    matingpool.Add(entry.Key);
                }
            }

            // Get New Population
            DNA[] newPopulation = populationToEvolve.createNewPopulation(matingpool);
            currentGeneration++;
            Debug.Print("Current DNA Fitness as Generation : " + currentGeneration.ToString());

            populationToEvolve.population = newPopulation;
            return evolvePopulation(currentDnaFitness, ref populationToEvolve, ref currentGeneration);

        }
    }
}
