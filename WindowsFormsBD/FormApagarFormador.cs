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
    public partial class FormApagarFormador : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormApagarFormador()
        {
            InitializeComponent();
        }

        private void FormApagarFormador_Load(object sender, EventArgs e)
        {
            txtNome.ReadOnly = true;
            txtNif.ReadOnly = true;
            mtxtDataNascimento.ReadOnly = true;
            dateTimePicker1.Visible = false;
            btnEliminar.Enabled = false;
            this.AcceptButton = this.btnPesquisa;
            ligacao.PreencherComboboxArea(ref cmbArea);

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            string nome = "", nif = "", dataNascimento = "", area = "";

            if (ligacao.PesquisaFormador(numIdFormador.Value.ToString(), ref nome, ref nif, ref dataNascimento, ref area))
            {
                txtNome.Text = nome;
                txtNif.Text = nif;
                mtxtDataNascimento.Text = dataNascimento;
                cmbArea.Text = ligacao.DevolverArea(area);

                groupBox3.Enabled = false;
                btnEliminar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Formador não encontrado!");
                limpar();
            }
        }

        private void limpar()
        {
            numIdFormador.Value = 0;
            txtNome.Text = string.Empty;
            txtNif.Text = "";
            mtxtDataNascimento.Clear();
            cmbArea.SelectedIndex = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            btnEliminar.Enabled = false;
            numIdFormador.Focus();
            limpar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Pretende elimar o registo ID " + numIdFormador.Value.ToString() + "?", "Atenção",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (ligacao.DeleteFormador(numIdFormador.Value.ToString()))
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
