using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex4_FORMATOS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Carregamento dos tipos de letra
            cmbTipo.Items.Add("Arial");
            cmbTipo.Items.Add("Times New Roman");
            cmbTipo.Items.Add("Verdana");
            cmbTipo.Text = "Arial"; //Tipo de letra predefinido

            //Carregamento dos tamanhos
            cmbTamanho.Items.Add("10");
            cmbTamanho.Items.Add("12");
            cmbTamanho.Items.Add("14");
            cmbTamanho.Text = "10"; //Tamanho predefinido

            //Carregamento dos estilos
            cmbEstilo.Items.Add("Normal");
            cmbEstilo.Items.Add("Negrito");
            cmbEstilo.Items.Add("Itálico");
            cmbEstilo.Items.Add("Sublinhado");
            cmbEstilo.Text = "Normal"; //Estilo predefinido

        }

        //Método
        void Formatar()
        {
            //Verificação do tipo de letra selecionado
            string tipo;
            tipo = cmbTipo.Text;

            //Verificação do tamanho selecionado
            int tamanho;
            tamanho = int.Parse(cmbTamanho.Text);

            //Verificação do estilo selecionado
            FontStyle estilo = new FontStyle();
            switch (cmbEstilo.Text)
            {
                case "Normal":
                    estilo = FontStyle.Regular; 
                    break;

                case "Negrito":
                    estilo = FontStyle.Bold;
                    break;

                case "Itálico":
                    estilo = FontStyle.Italic;
                    break;

                case "Sublinhado":
                    estilo = FontStyle.Underline;
                    break;
            }

            //Aplicação do formato
            richTextBox1.SelectionFont = new Font(tipo, tamanho, estilo);
        }


        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(richTextBox1.SelectionLength > 0)
            {
                Formatar();
            }
        }

        private void cmbTamanho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                Formatar();
            }
        }

        private void cmbEstilo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                Formatar();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Formatar();
        }
    }
}
