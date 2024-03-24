using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//Elaborado por Diana Freixo

namespace Ex2_FICHEIROS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo dirImagens = new DirectoryInfo("C:/Users/ASUS/OneDrive - Instituto Politécnico do Cávado e do Ave/Desktop/C#/3935/3935/Ex2_FICHEIROS/pictures");


                FileInfo[] ficheiros;
                ficheiros = dirImagens.GetFiles();

                int numFicheiros = ficheiros.Length;
                numericUpDown1.Minimum = 1;
                numericUpDown1.Maximum = numFicheiros;

                int numFichEscolhido;
                numFichEscolhido = (int)numericUpDown1.Value - 1;

                string caminhoFichEscolhido;
                caminhoFichEscolhido = ficheiros[numFichEscolhido].FullName;
                pictureBox1.BackgroundImage = Image.FromFile(caminhoFichEscolhido);
                toolTip1.SetToolTip(pictureBox1, caminhoFichEscolhido);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Este ficheiro não é do tipo imagem!", "Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
                if (listBox1.Text == "-")
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    pictureBox1.ImageLocation = "C:/Users/ASUS/OneDrive - Instituto Politécnico do Cávado e do Ave/Desktop/C#/3935/3935/Ex2_FICHEIROS/pictures1/" + listBox1.Text + ".png";
                }


        }
    }
}
