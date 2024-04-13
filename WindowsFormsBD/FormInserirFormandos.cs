using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsBD
{
    public partial class FormInserirFormandos : Form
    {
        DBConnect ligacao = new DBConnect();
        private string contactoAux = "";
        int id_nacionalidade = 0;
        public FormInserirFormandos()
        {
            InitializeComponent();
        }

        private void FormInserirFormandos_Load(object sender, EventArgs e)
        {
            numUDid.Value = ligacao.DevolveUltimoID();
            ligacao.PreencherComboboxNacionalidade(ref cmbNacionalidade);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if(verificarCampos())
            {
                if (ligacao.Insert(numUDid.Value.ToString(), txtNome.Text, txtMorada.Text, contactoAux,
                    mtxtIban.Text, genero(), DateTime.Parse(mtxtDataNascimento.Text).ToString("yyyy-MM-dd"), id_nacionalidade))
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

        // método para verificar se os campos estão bem preenchidos
        private bool verificarCampos()
        {
            if (numUDid.Value == 0)
            {
                MessageBox.Show("Erro no campo ID!");
                numUDid.Focus();
                return false;
            }

            txtNome.Text = Geral.removerEspacos(txtNome.Text);
            if (txtNome.Text.Length < 3)
            {
                MessageBox.Show("Erro no campo Nome!");
                txtNome.Focus();
                return false;
            }


            txtMorada.Text = Geral.removerEspacos(txtMorada.Text);
            if (txtMorada.Text.Length < 3)
            {
                MessageBox.Show("Erro no campo Morada!");
                txtMorada.Focus();
                return false;
            }

            contactoAux = mtxtContacto.Text.Replace(" ", "");
            if (contactoAux.Length != 0 && contactoAux.Length != 9)
            {
                MessageBox.Show("Erro no campo Contacto!");
                mtxtContacto.Focus();
                return false;
            }

            if (mtxtIban.Text.Length < 25)
            {
                MessageBox.Show("Erro no campo IBAN!");
                mtxtIban.Focus();
                return false;
            }

            if(genero()== 'T')
            {
                MessageBox.Show("Erro no campo Sexo!");
                rbFeminino.Focus();
                return false;
            }

            if (mtxtDataNascimento.Text.Length != 10 || Geral.checkDate(mtxtDataNascimento.Text)==false)
            {
                MessageBox.Show("Erro no campo Data de Nascimento!");
                mtxtDataNascimento.Focus();
                return false;
            }

            if (cmbNacionalidade.SelectedIndex == -1)
            {
                MessageBox.Show("Erro no campo Nacionalidade!");
                cmbNacionalidade.Focus();
                return false;
            }

            return true;
        }

        private char genero()
        {
            char genero = 'T';

            if (rbFeminino.Checked)
            {
                genero = 'F';
            }
            else if (rbMasculino.Checked)
            {
                genero = 'M';
            }
            else if (rbOutro.Checked)
            {
                genero = 'O';
            }

            return genero;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            mtxtDataNascimento.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void mtxtDataNascimento_TextChanged(object sender, EventArgs e)
        {
            int dia, mes, ano;
            string textoData;
            DateTime data;
            if(mtxtDataNascimento.MaskCompleted == true)
            {
                textoData = mtxtDataNascimento.Text;
                dia = int.Parse(textoData.Substring(0,2));
                mes = int.Parse(textoData.Substring(3,2));
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
        private void limpar()
        {
            numUDid.Value = ligacao.DevolveUltimoID();
            txtNome.Text = string.Empty;
            txtMorada.Text = "";
            mtxtContacto.Clear();
            mtxtIban.Text = string.Empty;
            rbFeminino.Checked = false;
            rbMasculino.Checked = false;
            rbOutro.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            mtxtDataNascimento.Clear();
            cmbNacionalidade.SelectedIndex = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbNacionalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se algum item está selecionado
            if (cmbNacionalidade.SelectedIndex >= 0)
            {
                id_nacionalidade = int.Parse(ExtrairIdNacionalidade(cmbNacionalidade.Text));
            }
        }

        // Método para extrair o id_nacionalidade da string nacionalidadeCombo
        private string ExtrairIdNacionalidade(string nacionalidadeCombo)
        {
            string[] partes = nacionalidadeCombo.Split(new string[] { " - " }, StringSplitOptions.None);
            return partes[partes.Length - 1];
        }
    }
}
