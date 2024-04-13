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
    public partial class FormAutenticacao : Form
    {
        DBConnect ligacao = new DBConnect();
        //public string username = "";
        public FormAutenticacao()
        {
            InitializeComponent();
        }

        private void FormAutenticacao_Load(object sender, EventArgs e)
        {
            txtUtilizador.Text = "";
            txtPalavraPasse.Text = "";
            ControlBox = false;
            AcceptButton = btnLogin;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int nFalhas = 0;

            if (ligacao.ValidateUsersStatus(txtUtilizador.Text, ref nFalhas))
            {
                MessageBox.Show("Utilizador bloqueado! Nº Tentativas de autenticação: "+nFalhas+"\nContacte o Administrador do Sistema.");
            }

            /*
            if(ligacao.ValidateUsersStatus(txtUtilizador.Text))
            {
                MessageBox.Show("Utilizador bloqueado!\nContacte o Administrador do Sistema.");
            }
            */


            // if(ligacao.ValidateUsers(txtUtilizador.Text, txtPalavraPasse.Text, ref username))
            //if(ligacao.ValidateUsers(txtUtilizador.Text, txtPalavraPasse.Text, ref Geral.id_user))
            if (ligacao.ValidateUsers2(txtUtilizador.Text, txtPalavraPasse.Text, ref Geral.id_user))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Erro na autenticação");
                txtUtilizador.Text = "";
                txtPalavraPasse.Text = "";
            }
        }
    }
}
