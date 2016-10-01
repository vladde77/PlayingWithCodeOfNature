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
            Population population = new Population(populationSize);
            var currentValue = 0;
            string targetPhrase = "To be or not to be";

            var matingpool = new List<DNA>();


            foreach (DNA dna in population.populationSize)
            {
                currentValue++;
                Debug.Print("Current DNA: " + currentValue.ToString());
                Debug.Print("Current DNA: " + new string(dna.genes));

                var currentDnaFitness = population.Fitness(targetPhrase, dna);
                Debug.Print("Current DNA Fitness: " + currentDnaFitness.ToString());

                int n = (int)population.Fitness(targetPhrase, dna) * 100;

                for (int j = 0; j < n; j++)
                {
                    matingpool.Add(dna);
                }
            }
        }
    }
}
