using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;

namespace WindowsFormsBD
{
    public partial class FormInserirFormador : Form
    {
        DBConnect ligacao = new DBConnect();
        int id_area = 0;
        public FormInserirFormador()
        {
            InitializeComponent();
        }

        private void FormInserirFormador_Load(object sender, EventArgs e)
        {
            numIdFormador.Value = ligacao.DevolveUltimoIDFormador();
            ligacao.PreencherComboboxArea(ref cmbArea);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (verificarCampos())
            {
                if (ligacao.InsertFormador(numIdFormador.Value.ToString(), txtNome.Text, txtNif.Text,
                    DateTime.Parse(mtxtDataNascimento.Text).ToString("yyyy-MM-dd"), id_area)) 
                {
                    MessageBox.Show("Registo gravado com sucesso!");
                    limpar();
                    txtNome.Focus();
                }
                else
                {
                    MessageBox.Show("Erro ao gravar o registo!");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
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


        private void limpar()
        {
            numIdFormador.Value = ligacao.DevolveUltimoIDFormador();
            txtNome.Text = string.Empty;
            txtNif.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            mtxtDataNascimento.Clear();
            cmbArea.SelectedIndex = -1;
        }


        private void cmbArea_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Verifica se algum item está selecionado
            if (cmbArea.SelectedIndex >= 0)
            {
                id_area = int.Parse(ExtrairIdArea(cmbArea.Text));   
            }
        }


        private string ExtrairIdArea(string areaCombo)
        {

            string idArea = areaCombo.Substring(0, areaCombo.IndexOf(" -"));

            return idArea;

        }

        private void mtxtDataNascimento_TextChanged_1(object sender, EventArgs e)
        {
            int dia, mes, ano;
            string textoData;
            DateTime data;
            if (mtxtDataNascimento.MaskCompleted == true)
            {
                textoData = mtxtDataNascimento.Text;
                dia = int.Parse(textoData.Substring(0, 2));
                mes = int.Parse(textoData.Substring(3, 2));
                ano = int.Parse(textoData.Substring(6));

                try
                {
                    data = DateTime.Parse(dia + "-" + mes + "-" + ano);
                    dateTimePicker1.Value = data;
                }
                catch
                {
                    MessageBox.Show("Data incorreta!", "Erro", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    mtxtDataNascimento.Focus();
                }
            }
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            mtxtDataNascimento.Text = dateTimePicker1.Value.ToShortDateString();
        }
    }
}
