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
    public partial class FormApagarNacionalidade : Form
    {
        DBConnect ligacao = new DBConnect();
        string id_nacionalidade = "";
        public FormApagarNacionalidade()
        {
            InitializeComponent();
        }

        private void FormApagarNacionalidade_Load(object sender, EventArgs e)
        {
            ligacao.PreencherComboboxNacionalidade(ref cmbNacionalidade);
            desativarControlos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja eliminar a nacionalidade " + txtNacionalidade.Text + "?", "Eliminar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (ligacao.DeleteNacionalidade(id_nacionalidade))
                {
                    MessageBox.Show("Registo eliminado com sucesso!");
                    cmbNacionalidade.Items.Clear();
                    ligacao.PreencherComboboxNacionalidade(ref cmbNacionalidade);
                    limpar();
                }
                else
                {
                    MessageBox.Show("Erro na eliminação do registo!");
                }
            }
        }

        private void cmbNacionalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se algum item está selecionado
            if (cmbNacionalidade.SelectedIndex >= 0) // != -1
            {
                string alf2 = "", nacionalidade = "";

                id_nacionalidade = ExtrairIdNacionalidade(cmbNacionalidade.Text);
                ligacao.PesquisaNacionalidade(id_nacionalidade, ref alf2, ref nacionalidade);

                txtALF2.Text = alf2;
                txtNacionalidade.Text = nacionalidade;

                btnEliminar.Enabled = true;
            }
        }


        // Método para extrair o id_nacionalidade da string nacionalidadeCombo
        string ExtrairIdNacionalidade(string nacionalidadeCombo)
        {
            string[] partes = nacionalidadeCombo.Split(new string[] { " - " }, StringSplitOptions.None);
            return partes[partes.Length - 1];
            /*
            string idNacionalidade = nacionalidadeCombo.Substring(nacionalidadeCombo.LastIndexOf(' ') + 1);
            return idNacionalidade;
            */
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpar();
            groupBox3.Enabled = true;
            btnEliminar.Enabled = false;
            cmbNacionalidade.Focus();
            desativarControlos();
        }

        private void desativarControlos()
        {
            txtALF2.ReadOnly = true;
            txtNacionalidade.ReadOnly = true;
            btnEliminar.Enabled = false;
        }

        private void limpar()
        {
            cmbNacionalidade.Text = "";
            txtALF2.Text = string.Empty;
            txtNacionalidade.Text = "";
        }
    }
}
