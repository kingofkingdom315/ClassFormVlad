using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryVlad;
using System.Windows.Forms;

namespace ClassFormVlad
{
    public partial class Form1 : Form
    {
        CMatrix mass;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mass = new CMatrix(int.Parse(textBox1.Text));
            Random rand = new Random();
            for (int i = 0; i < mass.getLengthMatrix; i++)
            {
                for (int j = 0; j < mass.getLengthMatrix; j++)
                {
                    mass[i, j] = rand.Next(0, 100);
                    richTextBox1.Text += mass[i, j].ToString() + ':';
                }
                richTextBox1.Text += "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 1;
            foreach (char m in textBox2.Text)
            {
                if (m == ':' || m == ';')
                    i++;

            }
            if (textBox2.Text[textBox2.Text.Length - 1] == ':' || textBox2.Text[textBox2.Text.Length - 1] == ';')
                i--;
            double[,] massbuf = new double[Convert.ToInt32(Math.Sqrt(i)), Convert.ToInt32(Math.Sqrt(i))];
            string cursor = "";
            i = 0;
            int j = 0;
            for (int c = 0; c < textBox2.Text.Length; c++)
            {
                if (textBox2.Text[c] != ':' && textBox2.Text[c] != ';')
                {
                    cursor += textBox2.Text[c];
                }
                else if (textBox2.Text[c] == ';')
                {
                    massbuf[i, j] = int.Parse(cursor);
                    cursor = "";
                    i++;
                    j = 0;
                }
                else
                {
                    massbuf[i, j] = int.Parse(cursor);
                    cursor = "";
                    j++;
                }
            }
            if (cursor != "")
                massbuf[i, j] = int.Parse(cursor);
            mass = new CMatrix(massbuf);
            for (int c = 0; c < mass.getLengthMatrix; c++)
            {
                for (int k = 0; k < mass.getLengthMatrix; k++)
                {
                    richTextBox1.Text += mass[c, k].ToString() + ':';
                }
                richTextBox1.Text += "\n";
            }
        }
    }
}
