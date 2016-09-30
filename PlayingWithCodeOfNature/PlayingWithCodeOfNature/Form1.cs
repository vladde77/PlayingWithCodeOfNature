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
            Population population = new Population();
            var currentValue = 1;
            foreach (DNA dna in population.population)
            {
                currentValue++;
                Debug.Print("Current DNA: " + currentValue.ToString());
                Debug.Print("Current DNA: " + new string(dna.genes));
            }
        }
    }
}
