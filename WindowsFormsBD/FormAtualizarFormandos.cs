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
    public partial class FormAtualizarFormandos : Form
    {
        DBConnect ligacao = new DBConnect();
        string contactoAux = "";
        public FormAtualizarFormandos()
        {
            InitializeComponent();
        }

        private void FormAtualizarFormandos_Load(object sender, EventArgs e)
        {
            desativarControlos();
            btnAtualizar.Enabled = false;
            this.AcceptButton = this.btnPesquisa;
            ligacao.PreencherComboboxNacionalidade(ref cmbNacionalidade);
        }

        private void desativarControlos()
        {
            txtNome.ReadOnly = true;
            txtMorada.ReadOnly = true;
            mtxtContacto.ReadOnly = true;
            mtxtIban.ReadOnly = true;
            rbFeminino.Enabled = false;
            rbMasculino.Enabled = false;
            rbOutro.Enabled = false;
            mtxtDataNascimento.ReadOnly = true;
            dateTimePicker1.Visible = false;
            btnAtualizar.Enabled = false;
            this.AcceptButton = this.btnPesquisa;
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            string nome = "", morada = "", contacto = "", iban = "", dataNascimento = "", nacionalidade = "";
            char genero = ' ';

            if (ligacao.PesquisaFormando(numUDid.Value.ToString(), ref nome, ref morada,
                ref contacto, ref iban, ref genero, ref dataNascimento, ref nacionalidade))
            {
                txtNome.Text = nome;
                txtMorada.Text = morada;
                mtxtContacto.Text = contacto;
                mtxtIban.Text = iban;
                if (genero == 'F')
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
                cmbNacionalidade.Text = ligacao.DevolverNacionalidade(nacionalidade);

                groupBox3.Enabled = false;
                btnAtualizar.Enabled = true;

                txtNome.ReadOnly = false;
                txtMorada.ReadOnly = false;
                mtxtContacto.ReadOnly = false;
                mtxtIban.ReadOnly = false;
                rbFeminino.Enabled = true;
                rbMasculino.Enabled = true;
                rbOutro.Enabled = true;
                mtxtDataNascimento.ReadOnly = false;
                dateTimePicker1.Visible = false;
                cmbNacionalidade.Enabled = true;
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
            cmbNacionalidade.SelectedIndex = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            btnAtualizar.Enabled = false;
            numUDid.Focus();
            limpar();
            desativarControlos();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
         
            string id_nacionalidade = cmbNacionalidade.Text.Substring(cmbNacionalidade.Text.LastIndexOf(' ') + 1);

            if (verificarCampos())
            {
                if (ligacao.Update(numUDid.Value.ToString(), txtNome.Text, txtMorada.Text, contactoAux,
                    mtxtIban.Text, genero(), DateTime.Parse(mtxtDataNascimento.Text).ToString("yyyy-MM-dd"), id_nacionalidade))
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

            if (genero() == 'T')
            {
                MessageBox.Show("Erro no campo Sexo!");
                rbFeminino.Focus();
                return false;
            }

            if (mtxtDataNascimento.Text.Length != 10 || Geral.checkDate(mtxtDataNascimento.Text) == false)
            {
                MessageBox.Show("Erro no campo Data de Nascimento!");
                mtxtDataNascimento.Focus();
                return false;
            }

            if(cmbNacionalidade.SelectedIndex == -1) 
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
    }
}
