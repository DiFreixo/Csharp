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
    public partial class FormAtualizarFormador : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormAtualizarFormador()
        {
            InitializeComponent();
        }

        private void FormAtualizarFormador_Load(object sender, EventArgs e)
        {
            desativarControlos();
            btnAtualizar.Enabled = false;
            this.AcceptButton = this.btnPesquisa;
            ligacao.PreencherComboboxArea(ref cmbArea);
        }

        private void desativarControlos()
        {
            txtNome.ReadOnly = true;
            txtNif.ReadOnly = true;
            mtxtDataNascimento.ReadOnly = true;
            dateTimePicker1.Visible = false;
            btnAtualizar.Enabled = false;
            this.AcceptButton = this.btnPesquisa;
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            string nome = "", nif = "", dataNascimento = "", area = "";

            if (ligacao.PesquisaFormador(numIdFormador.Value.ToString(), ref nome, ref nif,
                ref dataNascimento, ref area)) 
            {
                txtNome.Text = nome;
                txtNif.Text = nif;
                    
                mtxtDataNascimento.Text = dataNascimento;
                cmbArea.Text = ligacao.DevolverArea(area);

                groupBox3.Enabled = false;
                btnAtualizar.Enabled = true;

                txtNome.ReadOnly = false;
                txtNif.ReadOnly = false;
                mtxtDataNascimento.ReadOnly = false;
                dateTimePicker1.Visible = false;
                cmbArea.Enabled = true;
            }
            else
            {
                MessageBox.Show("Formando não encontrado!");
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
            btnAtualizar.Enabled = false;
            numIdFormador.Focus();
            limpar();
            desativarControlos();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string id_area = cmbArea.Text.Substring(0, cmbArea.Text.IndexOf(" -"));

            if (verificarCampos())
            {
                if (ligacao.UpdateFormador(numIdFormador.Value.ToString(), txtNome.Text, txtNif.Text,
                     DateTime.Parse(mtxtDataNascimento.Text).ToString("yyyy-MM-dd"), id_area)) 
                {
                    MessageBox.Show("Registo atualizado com sucesso!");
                    btnCancelar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Erro na atualização do registo!");
                }
            }
        }

        private bool verificarCampos()
        {
            if (numIdFormador.Value == 0)
            {
                MessageBox.Show("Erro no campo ID!");
                numIdFormador.Focus();
                return false;
            }

            txtNome.Text = Geral.removerEspacos(txtNome.Text);
            if (txtNome.Text.Length < 3)
            {
                MessageBox.Show("Erro no campo Nome!");
                txtNome.Focus();
                return false;
            }


            txtNif.Text = Geral.removerEspacos(txtNif.Text);
            if (txtNif.Text.Length < 9)
            {
                MessageBox.Show("Erro no campo Nif!");
                txtNif.Focus();
                return false;
            }


            if (mtxtDataNascimento.Text.Length != 10 || Geral.checkDate(mtxtDataNascimento.Text) == false)
            {
                MessageBox.Show("Erro no campo Data de Nascimento!");
                mtxtDataNascimento.Focus();
                return false;
            }

            if (cmbArea.SelectedIndex == -1)
            {
                MessageBox.Show("Erro no campo Área!");
                cmbArea.Focus();
                return false;
            }

            return true;
        }

    }
}
