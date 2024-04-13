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
    public partial class FormInserirArea : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormInserirArea()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (verificarCampos())
            {
                if (ligacao.InsertArea(numIdArea.Value.ToString(), txtArea.Text))  
                {
                    MessageBox.Show("Registo gravado com sucesso!");
                    limpar();
                    numIdArea.Focus();
                }
                else
                {
                    MessageBox.Show("Erro ao gravar o registo!");
                }
            }
        }

        private void limpar()
        {
            numIdArea.Value = ligacao.DevolveUltimoIDArea(); 
            txtArea.Text = string.Empty;
        }
        // método para verificar se os campos estão bem preenchidos
        private bool verificarCampos()
        {


            if (numIdArea.Value == 0)
            {
                MessageBox.Show("Erro no campo ID!");
                numIdArea.Focus();
                return false;
            }

            txtArea.Text = Geral.removerEspacos(txtArea.Text);
            if (txtArea.Text.Length < 3)
            {
                MessageBox.Show("Erro no campo Área!");
                txtArea.Focus();
                return false;
            }
           
            return true;
        }

        private void btnCancelar_Click(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void FormInserirArea_Load(object sender, EventArgs e)
        {
            numIdArea.Value = ligacao.DevolveUltimoIDArea();

        }
    }
}
