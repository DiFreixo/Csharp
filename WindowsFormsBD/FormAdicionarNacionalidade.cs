using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsBD
{
    public partial class FormAdicionarNacionalidade : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormAdicionarNacionalidade()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (verificarCampos())
            {
                if (ligacao.InsertNacionalidade(txtALF2.Text, txtNacionalidade.Text))
                {
                    MessageBox.Show("Registo gravado com sucesso!");
                    limpar();
                    txtALF2.Focus();
                }
                else
                {
                    MessageBox.Show("Erro ao gravar o registo!");
                }
            }
        }

        private void limpar()
        {

            txtALF2.Text = string.Empty;
            txtNacionalidade.Text = "";
        }
        // método para verificar se os campos estão bem preenchidos
        private bool verificarCampos()
        {

            txtALF2.Text = Geral.removerEspacos(txtALF2.Text);
            if (txtALF2.Text.Length < 2)
            {
                MessageBox.Show("Erro no campo ALF2!");
                txtALF2.Focus();
                return false;
            }

            txtNacionalidade.Text = Geral.removerEspacos(txtNacionalidade.Text);
            if (txtNacionalidade.Text.Length < 3)
            {
                MessageBox.Show("Erro no campo Nacionalidade!");
                txtNacionalidade.Focus();
                return false;
            }
            
            return true;
        }

        private void btnCancelar_MouseUp(object sender, MouseEventArgs e)
        {
            /*
            if(e.Button == MouseButtons.Right) 
            {
                Close();
            }

            if (e.Button == MouseButtons.Left)
            {
                limpar();
            }
            */

            switch(e.Button)
            {
                case MouseButtons.Left:
                    limpar();
                    break;
                case MouseButtons.Right:
                    Close();
                    break;
            }
        }
    }
}
