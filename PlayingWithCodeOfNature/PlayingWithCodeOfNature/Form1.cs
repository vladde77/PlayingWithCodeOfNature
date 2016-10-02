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
            int populationSize = 100;
            string targetPhrase = "To be or not to be";
            float mutationRate = 0.01f;

            Population population = new Population(populationSize, targetPhrase.Length);

            var matingpool = new List<DNA>();

            foreach (DNA dna in population.populationSize)
            {

                var currentDnaFitness = population.Fitness(targetPhrase, dna);
                int n = (int)(population.Fitness(targetPhrase, dna) * 100);
                Debug.Print("Current DNA Fitness as n : " + n.ToString());

                for (int j = 0; j < n; j++)
                {
                    matingpool.Add(dna);
                }
            }

            // Get New Population
            DNA[] newPop = population.createNewPopulation(matingpool, mutationRate);


        }
    }
}
