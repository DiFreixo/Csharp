using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsBD
{
    public partial class FormApagar : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormApagar()
        {
            InitializeComponent();
        }

        private void FormApagar_Load(object sender, EventArgs e)
        {
            //groupBox1.Enabled = false;
            txtNome.ReadOnly = true;
            txtMorada.ReadOnly = true;
            mtxtContacto.ReadOnly = true;
            mtxtIban.ReadOnly = true;
            rbFeminino.Enabled = false;
            rbMasculino.Enabled = false;
            rbOutro.Enabled = false;
            mtxtDataNascimento.ReadOnly = true;
            dateTimePicker1.Visible = false;
            btnEliminar.Enabled = false;
            this.AcceptButton = this.btnPesquisa;
           
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            string nome = "", morada = "", contacto = "", iban = "", dataNascimento = "";
            char genero = ' ';

            if (ligacao.PesquisaFormando(numUDid.Value.ToString(), ref nome, ref morada,
                ref contacto, ref iban, ref genero, ref dataNascimento))
            {
                txtNome.Text = nome;
                txtMorada.Text = morada;
                mtxtContacto.Text = contacto;
                mtxtIban.Text = iban;
                if(genero == 'F')
                {
                    rbFeminino.Checked = true;
                }
                else if (genero == 'M')
                {
                    rbMasculino.Checked = true;
                }
                else if (genero == 'O')
                {
                    rbOutro.Checked = true;
                }
                mtxtDataNascimento.Text = dataNascimento;

                groupBox3.Enabled = false;
                btnEliminar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Formando não encontrado!");
                limpar();
            }

        }
        private void limpar()
        {
            numUDid.Value = 0;
            txtNome.Text = string.Empty;
            txtMorada.Text = "";
            mtxtContacto.Clear();
            mtxtIban.Text = string.Empty;
            rbFeminino.Checked = false;
            rbMasculino.Checked = false;
            rbOutro.Checked = false;

            mtxtDataNascimento.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled=true;
            btnEliminar.Enabled = false;
            numUDid.Focus();
            limpar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Tem que confirmar com o utilizador primeiro se quer apagar o registo
            // É emitida a mensagem se foi eliminado com sucesso ou não
            // Limpa os campos caso for eliminado com sucesso

            /* 
             DialogResult dialogResult = MessageBox.Show("Pretende elimar o registo?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

             if (dialogResult == DialogResult.Yes)
             {
                 ligacao.Delete(numUDid.Value.ToString());
                 MessageBox.Show("Registo eliminado com sucesso!");
                 limpar();
             }
             else 
             {
                 MessageBox.Show("Erro ao elimiar registo!");  
             }
            */

            if(MessageBox.Show("Pretende elimar o registo ID " + numUDid.Value.ToString() + "?", "Atenção", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if(ligacao.Delete(numUDid.Value.ToString()))
                {
                    MessageBox.Show("Registo eliminado com sucesso!");
                    btnCancelar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Não foi possível eliminar o registo!");
                }
            }

        }
    }
}
