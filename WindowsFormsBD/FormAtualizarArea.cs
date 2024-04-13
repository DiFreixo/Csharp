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
    public partial class FormAtualizarArea : Form
    {
        DBConnect ligacao = new DBConnect();
        string id_area = "";
        public FormAtualizarArea()
        {
            InitializeComponent();
        }

        private void FormAtualizarArea_Load(object sender, EventArgs e)
        {
            ligacao.PreencherComboboxArea(ref cmbArea);   
            desativarControlos();
        }

        private void desativarControlos()
        {
            txtArea.ReadOnly = true;
            btnAtualizar.Enabled = false;
        }

        private void limpar()
        {
            txtArea.Text = string.Empty;
            cmbArea.Text = "";
        }

        private bool verificarCampos()
        {

            txtArea.Text = Geral.removerEspacos(txtArea.Text);
            if (txtArea.Text.Length < 3)
            {
                MessageBox.Show("Erro no campo Área!");
                txtArea.Focus();
                return false;
            }

            return true;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (verificarCampos())
            {
                if (ligacao.UpdateArea(id_area, txtArea.Text))  
                {
                    MessageBox.Show("Registo atualizado com sucesso!");
                    cmbArea.Items.Clear();
                    ligacao.PreencherComboboxArea(ref cmbArea);
                    limpar();
                }
                else
                {
                    MessageBox.Show("Erro na atualização do registo!");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpar();
            groupBox3.Enabled = true;
            btnAtualizar.Enabled = false;
            cmbArea.Focus();
            desativarControlos();
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se algum item está selecionado
            if (cmbArea.SelectedIndex >= 0)
            {
                string area = "";

                id_area = ExtrairIdArea(cmbArea.Text);
              
                ligacao.PesquisaArea(id_area, ref area);

                txtArea.Text = area;

                btnAtualizar.Enabled = true;
                txtArea.ReadOnly = false;
            }
        }

        string ExtrairIdArea(string areaCombo)
        {

            string idArea = areaCombo.Substring(0, areaCombo.IndexOf(" -"));

            return idArea;

        }
    }
}
