using System;
using System.Windows.Forms;

namespace BullsAndCows
{
    public partial class Form1 : Form
    {
        private static Random rnd = new Random();
        private string numToGuess = rnd.Next(1234, 9876+1).ToString();

        private int count = 0;
        public Form1()
        {
            InitializeComponent();

            GeneratedRandomNumber();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            var myNum = textBox1.Text;

            label1.Text = $"Secret num: {numToGuess}";
            var bulls = 0;
            var cows = 0;
            listBox1.Items.Clear();
            for (int i = 0; i < numToGuess.Length; i++)
            {
                if (myNum[i] == numToGuess[i])
                {
                    bulls++;
                }
            }

            for (int i = 0; i < numToGuess.Length - 1; i++)
            {
                for (int j = i + 1; j < numToGuess.Length; j++)
                {
                    if (myNum[i] == numToGuess[j])
                    {
                        cows++;
                    }
                }
            }

            for (int i = 0; i < numToGuess.Length - 1; i++)
            {
                for (int j = i + 1; j < numToGuess.Length; j++)
                {
                    if (numToGuess[i] == myNum[j])
                    {
                        cows++;
                    }
                }
            }

            listBox1.Items.Add($"Bulls: {bulls}");
            listBox1.Items.Add($"Cows: {cows}");

            if (count >= 10)
            {
                label2.Text = "Game Over!";
                MessageBox.Show("Game Over!");
                GeneratedRandomNumber();
            }
        }

        public void GeneratedRandomNumber()
        {
            var isBrake = false;
            while (true)
            {
                for (int i = 0; i < numToGuess.Length - 1; i++)
                {
                    for (int j = i + 1; j < numToGuess.Length; j++)
                    {
                        if (numToGuess[i] == numToGuess[j])
                        {
                            numToGuess = rnd.Next(1234, 9876).ToString();
                            isBrake = true;
                            break;
                        }
                    }
                    if (isBrake) break;
                }
                if (!isBrake) break;
            }
        }
    }
}
