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
            string targetPhrase = "to be or not to be";
            float mutationRate = 0.02f;

            Population population = new Population(populationSize, targetPhrase.Length, targetPhrase, mutationRate);

            int currentDnaFitness = 0;
            int currentGeneration = 0;
            var evolved = evolvePopulation(currentDnaFitness, ref population, ref currentGeneration);

        }

        //private int evolvePopulation(Population populationToEvolve, ref int currentDnaFitness)
        static int evolvePopulation(int currentDnaFitness, ref Population populationToEvolve, ref int currentGeneration)
        {

            var matingpool = new List<DNA>();
            foreach (DNA dna in populationToEvolve.population)
            {


                var currentDnaFitnessAsFloat = populationToEvolve.Fitness(dna);

                    
                //Debug.Print("Current DNA Fitness as currentDnaFitness : " + currentDnaFitnessAsFloat.ToString());

                currentDnaFitness = (int)(currentDnaFitnessAsFloat * 100);
                if (currentDnaFitness >= 100)
                {
                    Debug.Print(new string(dna.genes));
                    return 1;
                }

                for (int j = 0; j < currentDnaFitness; j++)
                {
                    matingpool.Add(dna);
                }
            }
            //Debug.Print("Matingpool size : " + matingpool.Count.ToString());

            
            // Get New Population
            DNA[] newPopulation = populationToEvolve.createNewPopulation(matingpool);
            currentGeneration++;
            Debug.Print("Current DNA Fitness as Generation : " + currentGeneration.ToString());

            populationToEvolve.population = newPopulation;
            return evolvePopulation(currentDnaFitness, ref populationToEvolve, ref currentGeneration);

        }
    }
}
