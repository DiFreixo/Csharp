using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//Elaborado por Diana Freixo

namespace Ex3_Datas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            dateTimePicker1.Value = monthCalendar1.SelectionStart;
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            int dia, mes, ano;
            string textoData;
            DateTime data;

            if(maskedTextBox1.MaskCompleted == true)
            {
                textoData = maskedTextBox1.Text;
                dia = int.Parse(textoData.Substring(0,2));
                mes = int.Parse(textoData.Substring(3, 2));
                ano = int.Parse(textoData.Substring(6, 4));

                try
                {
                    data = DateTime.Parse(dia + "-" + mes + "-" + ano);
                    dateTimePicker1.Value = data;
                    monthCalendar1.SelectionStart = data;
                }
                catch
                {
                    MessageBox.Show("Data incorreta!", "Erro!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

      

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
           
            if (sender is System.Windows.Forms.TextBox textBox1)
            {
                var text = textBox1.Text.Replace("-", "");
                if (text.Length >= 2 && text.Length < 4)
                {
                    textBox1.Text = text.Insert(2, "-");
                    textBox1.Select(textBox1.Text.Length, 0);
                }
                else if (text.Length >= 4)
                {
                    textBox1.Text = text.Insert(2, "-").Insert(5, "-");
                    textBox1.Select(textBox1.Text.Length, 0);
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           

                try
                {
               
                }
                catch (Exception)
                {
                    MessageBox.Show("Data incorreta!", "Erro!",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }
    }
}
