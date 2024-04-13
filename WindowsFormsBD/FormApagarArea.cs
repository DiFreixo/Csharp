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
    public partial class FormApagarArea : Form
    {
        DBConnect ligacao = new DBConnect();
        string id_area = "";
        public FormApagarArea()
        {
            InitializeComponent();
        }

        private void FormApagarArea_Load(object sender, EventArgs e)
        {
            ligacao.PreencherComboboxArea(ref cmbArea);
            desativarControlos();
        }

        private void desativarControlos()
        {
            txtArea.ReadOnly = true;
            btnEliminar.Enabled = false;
        }

        private void limpar()
        {
            cmbArea.Text = "";
            txtArea.Text = string.Empty;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpar();
            groupBox3.Enabled = true;
            btnEliminar.Enabled = false;
            cmbArea.Focus();
            desativarControlos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja eliminar a área " + txtArea.Text + "?", "Eliminar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (ligacao.DeleteArea(id_area))  
                {
                    MessageBox.Show("Registo eliminado com sucesso!");
                    cmbArea.Items.Clear();
                    ligacao.PreencherComboboxArea(ref cmbArea);
                    limpar();
                }
                else
                {
                    MessageBox.Show("Erro na eliminação do registo!");
                }
            }

        }
 
        string ExtrairIdArea(string areaCombo)
        {

            string idArea = areaCombo.Substring(0, areaCombo.IndexOf(" -"));

            return idArea;
            
        }

        private void cmbArea_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Verifica se algum item está selecionado
            if (cmbArea.SelectedIndex >= 0)
            {
                string area = "";

                id_area = ExtrairIdArea(cmbArea.Text);

                ligacao.PesquisaArea(id_area, ref area);

                txtArea.Text = area;

                btnEliminar.Enabled = true;

            }
        }
    }
}
