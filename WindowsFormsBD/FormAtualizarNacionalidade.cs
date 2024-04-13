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
    public partial class FormAtualizarNacionalidade : Form
    {
        DBConnect ligacao = new DBConnect();
        string id_nacionalidade = "";
        public FormAtualizarNacionalidade()
        {
            InitializeComponent();
        }

        private void FormAtualizarNacionalidade_Load(object sender, EventArgs e)
        {
            ligacao.PreencherComboboxNacionalidade(ref cmbNacionalidade);
            desativarControlos();
        }


        private void btnAtualizar_Click(object sender, EventArgs e)
        {

            if (verificarCampos())
            {
                if (ligacao.UpdateNacionalidade(id_nacionalidade, txtALF2.Text, txtNacionalidade.Text))
                {
                    MessageBox.Show("Registo atualizado com sucesso!");
                    cmbNacionalidade.Items.Clear();
                    ligacao.PreencherComboboxNacionalidade(ref cmbNacionalidade);
                    limpar();
                }
                else
                {
                    MessageBox.Show("Erro na atualização do registo!");
                }
            } 
        }


        // Método para extrair o id_nacionalidade da string nacionalidadeCombo
        private string ExtrairIdNacionalidade(string nacionalidadeCombo)
        {
            string[] partes = nacionalidadeCombo.Split(new string[] { " - " }, StringSplitOptions.None);
            return partes[partes.Length - 1];
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpar();
            groupBox3.Enabled = true;
            btnAtualizar.Enabled = false;
            cmbNacionalidade.Focus();
            desativarControlos();
        }

        private void limpar()
        {
            cmbNacionalidade.Text = "";
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

        private void desativarControlos()
        {
            txtALF2.ReadOnly = true;
            txtNacionalidade.ReadOnly = true;
            btnAtualizar.Enabled = false;
        }

        private void cmbNacionalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se algum item está selecionado
            if (cmbNacionalidade.SelectedIndex >= 0) 
            {
                string alf2 = "", nacionalidade = "";

                id_nacionalidade = ExtrairIdNacionalidade(cmbNacionalidade.Text);
                ligacao.PesquisaNacionalidade(id_nacionalidade, ref alf2, ref nacionalidade);

                txtALF2.Text = alf2;
                txtNacionalidade.Text = nacionalidade;

                btnAtualizar.Enabled = true;
                txtALF2.ReadOnly = false;
                txtNacionalidade.ReadOnly = false;
            }
        }
    }
}
