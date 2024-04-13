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
    public partial class FormPrincipal : Form
    {
        // intanciar o formulário globalmente
        FormInserirFormandos formInserirFormandos = new FormInserirFormandos();
        FormApagar formApagarFormandos = new FormApagar();
        FormAtualizarFormandos formAtualizarFormandos = new FormAtualizarFormandos();
        FormListarFormandos formListarFormandos = new FormListarFormandos();
        FormAdicionarNacionalidade formAdicionarNacionalidade = new FormAdicionarNacionalidade();
        FormApagarNacionalidade formApagarNacionalidade = new FormApagarNacionalidade();
        FormAtualizarNacionalidade formAtualizarNacionalidade = new FormAtualizarNacionalidade();
        FormListarNacionalidade formListarNacionalidade = new FormListarNacionalidade();
        FormAutenticacao formAutenticacao = new FormAutenticacao();
        FormInserirFormador formInserirFormador = new FormInserirFormador();
        FormInserirArea formInserirArea = new FormInserirArea();
        FormAtualizarFormador formAtualizarFormador = new FormAtualizarFormador();
        FormAtualizarArea formAtualizarArea = new FormAtualizarArea();
        FormApagarFormador formApagarFormador = new FormApagarFormador();
        FormApagarArea formApagarArea = new FormApagarArea();
        FormListarFormadores formListarFormadores = new FormListarFormadores();
        FormListarAreas formListarAreas = new FormListarAreas();
        public FormPrincipal()
        {
            InitializeComponent();
        }

        // Inserir Formandos
        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //verifica se o form foi eliminado, caso sim, instancia novamente
            if (formInserirFormandos.IsDisposed) 
            {
                formInserirFormandos = new FormInserirFormandos(); ;
            }
            formInserirFormandos.MdiParent = this;
            // posicionar o form no ecrã
            formInserirFormandos.StartPosition = FormStartPosition.Manual;
            formInserirFormandos.Location = new Point((this.ClientSize.Width - formInserirFormandos.Width) / 2, 
                                            (this.ClientSize.Height - formInserirFormandos.Height) / 3);
            formInserirFormandos.Show();
            formInserirFormandos.Activate();
        }


        // Apagar Formandos
        private void apagarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //verifica se o form foi eliminado, caso sim, instancia novamente
            if (formApagarFormandos.IsDisposed)
            {
                formApagarFormandos = new FormApagar(); ;
            }
            formApagarFormandos.MdiParent = this;
            // posicionar o form no ecrã
            formApagarFormandos.StartPosition = FormStartPosition.Manual;
            formApagarFormandos.Location = new Point((this.ClientSize.Width - formApagarFormandos.Width) / 2,
                                            (this.ClientSize.Height - formApagarFormandos.Height) / 3);
            formApagarFormandos.Show();
            formApagarFormandos.Activate();
        }

        // Atualizar Formandos
        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //verifica se o form foi eliminado, caso sim, instancia novamente
            if (formAtualizarFormandos.IsDisposed)
            {
                formAtualizarFormandos = new FormAtualizarFormandos(); ;
            }
            formAtualizarFormandos.MdiParent = this;
            // posicionar o form no ecrã
            formAtualizarFormandos.StartPosition = FormStartPosition.Manual;
            formAtualizarFormandos.Location = new Point((this.ClientSize.Width - formAtualizarFormandos.Width) / 2,
                                            (this.ClientSize.Height - formAtualizarFormandos.Height) / 3);
            formAtualizarFormandos.Show();
            formAtualizarFormandos.Activate();
        }

        // Listar Formandos
        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //verifica se o form foi eliminado, caso sim, instancia novamente
            if (formListarFormandos.IsDisposed)
            {
                formListarFormandos = new FormListarFormandos(); ;
            }
            formListarFormandos.MdiParent = this;
            // posicionar o form no ecrã
            formListarFormandos.StartPosition = FormStartPosition.Manual;
            formListarFormandos.Location = new Point((this.ClientSize.Width - formListarFormandos.Width) / 2,
                                            (this.ClientSize.Height - formListarFormandos.Height) / 3);
            formListarFormandos.Show();
            formListarFormandos.Activate();
        }

        // inserir nacionalidade
        private void inserirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //verifica se o form foi eliminado, caso sim, instancia novamente
            if (formAdicionarNacionalidade.IsDisposed)
            {
                formAdicionarNacionalidade = new FormAdicionarNacionalidade(); ;
            }
            formAdicionarNacionalidade.MdiParent = this;
            // posicionar o form no ecrã
            formAdicionarNacionalidade.StartPosition = FormStartPosition.Manual;
            formAdicionarNacionalidade.Location = new Point((this.ClientSize.Width - formAdicionarNacionalidade.Width) / 2,
                                            (this.ClientSize.Height - formAdicionarNacionalidade.Height) / 3);
            formAdicionarNacionalidade.Show();
            formAdicionarNacionalidade.Activate();
        }

        // ATUALIZAR nacionalidade
        private void apagarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //verifica se o form foi eliminado, caso sim, instancia novamente
            if (formAtualizarNacionalidade.IsDisposed)
            {
                formAtualizarNacionalidade = new FormAtualizarNacionalidade(); ;
            }
            formAtualizarNacionalidade.MdiParent = this;
            // posicionar o form no ecrã
            formAtualizarNacionalidade.StartPosition = FormStartPosition.Manual;
            formAtualizarNacionalidade.Location = new Point((this.ClientSize.Width - formAtualizarNacionalidade.Width) / 2,
                                            (this.ClientSize.Height - formAtualizarNacionalidade.Height) / 3);
            formAtualizarNacionalidade.Show();
            formAtualizarNacionalidade.Activate();
        }

        // apagar nacionalidade
        private void apagarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //verifica se o form foi eliminado, caso sim, instancia novamente
            if (formApagarNacionalidade.IsDisposed)
            {
                formApagarNacionalidade = new FormApagarNacionalidade(); ;
            }
            formApagarNacionalidade.MdiParent = this;
            // posicionar o form no ecrã
            formApagarNacionalidade.StartPosition = FormStartPosition.Manual;
            formApagarNacionalidade.Location = new Point((this.ClientSize.Width - formApagarNacionalidade.Width) / 2,
                                            (this.ClientSize.Height - formApagarNacionalidade.Height) / 3);
            formApagarNacionalidade.Show();
            formApagarNacionalidade.Activate();
        }

        // listar nacionalidade
        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //verifica se o form foi eliminado, caso sim, instancia novamente
            if (formListarNacionalidade.IsDisposed)
            {
                formListarNacionalidade = new FormListarNacionalidade(); ;
            }
            formListarNacionalidade.MdiParent = this;
            // posicionar o form no ecrã
            formListarNacionalidade.StartPosition = FormStartPosition.Manual;
            formListarNacionalidade.Location = new Point((this.ClientSize.Width - formListarNacionalidade.Width) / 2,
                                            (this.ClientSize.Height - formListarNacionalidade.Height) / 3);
            formListarNacionalidade.Show();
            formListarNacionalidade.Activate();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "";
            toolStripButton1.Enabled = false;
            formAutenticacao.ShowDialog();
            //toolStripLabel1.Text = "Perfil: " + formAutenticacao.username;
            toolStripLabel1.Text = "Perfil: " + Geral.id_user;
            toolStripButton1.Enabled = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja efetuar logout?\nTodas as janelas serão fechadas.", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Form frm in this.MdiChildren)
                {
                    frm.Dispose();
                    frm.Close();
                }

                toolStripLabel1.Text = "";
                toolStripButton1.Enabled = false;
                formAutenticacao.ShowDialog();
                toolStripLabel1.Text = "Perfil: " + Geral.id_user;
                toolStripButton1.Enabled = true;
            }
        }

        // inserir formadores
        private void inserirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //verifica se o form foi eliminado, caso sim, instancia novamente
            if (formInserirFormador.IsDisposed)
            {
                formInserirFormador = new FormInserirFormador(); ;
            }
            formInserirFormador.MdiParent = this;
            // posicionar o form no ecrã
            formInserirFormador.StartPosition = FormStartPosition.Manual;
            formInserirFormador.Location = new Point((this.ClientSize.Width - formInserirFormador.Width) / 2,
                                            (this.ClientSize.Height - formInserirFormador.Height) / 3);
            formInserirFormador.Show();
            formInserirFormador.Activate();
        }

        // inserir áreas
        private void inserirToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //verifica se o form foi eliminado, caso sim, instancia novamente
            if (formInserirArea.IsDisposed)
            {
                formInserirArea = new FormInserirArea(); ;
            }
            formInserirArea.MdiParent = this;
            // posicionar o form no ecrã
            formInserirArea.StartPosition = FormStartPosition.Manual;
            formInserirArea.Location = new Point((this.ClientSize.Width - formInserirArea.Width) / 2,
                                            (this.ClientSize.Height - formInserirArea.Height) / 3);
            formInserirArea.Show();
            formInserirArea.Activate();
        }

        // atualizar formador
        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //verifica se o form foi eliminado, caso sim, instancia novamente
            if (formAtualizarFormador.IsDisposed)
            {
                formAtualizarFormador = new FormAtualizarFormador(); ;
            }
            formAtualizarFormador.MdiParent = this;
            // posicionar o form no ecrã
            formAtualizarFormador.StartPosition = FormStartPosition.Manual;
            formAtualizarFormador.Location = new Point((this.ClientSize.Width - formAtualizarFormador.Width) / 2,
                                            (this.ClientSize.Height - formAtualizarFormador.Height) / 3);
            formAtualizarFormador.Show();
            formAtualizarFormador.Activate();
        }


        // atualizar área
        private void atualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //verifica se o form foi eliminado, caso sim, instancia novamente
            if (formAtualizarArea.IsDisposed)
            {
                formAtualizarArea = new FormAtualizarArea(); ;
            }
            formAtualizarArea.MdiParent = this;
            // posicionar o form no ecrã
            formAtualizarArea.StartPosition = FormStartPosition.Manual;
            formAtualizarArea.Location = new Point((this.ClientSize.Width - formAtualizarArea.Width) / 2,
                                            (this.ClientSize.Height - formAtualizarArea.Height) / 3);
            formAtualizarArea.Show();
            formAtualizarArea.Activate();
        }

        // apagar formador
        private void apagarToolStripMenuItem4_Click(object sender, EventArgs e)
        {

            //verifica se o form foi eliminado, caso sim, instancia novamente
            if (formApagarFormador.IsDisposed)
            {
                formApagarFormador = new FormApagarFormador(); ;
            }
            formApagarFormador.MdiParent = this;
            // posicionar o form no ecrã
            formApagarFormador.StartPosition = FormStartPosition.Manual;
            formApagarFormador.Location = new Point((this.ClientSize.Width - formApagarFormador.Width) / 2,
                                            (this.ClientSize.Height - formApagarFormador.Height) / 3);
            formApagarFormador.Show();
            formApagarFormador.Activate();
        }

        // apagar área
        private void apagarToolStripMenuItem5_Click(object sender, EventArgs e)
        {

            //verifica se o form foi eliminado, caso sim, instancia novamente
            if (formApagarArea.IsDisposed)
            {
                formApagarArea = new FormApagarArea(); ;
            }
            formApagarArea.MdiParent = this;
            // posicionar o form no ecrã
            formApagarArea.StartPosition = FormStartPosition.Manual;
            formApagarArea.Location = new Point((this.ClientSize.Width - formApagarArea.Width) / 2,
                                            (this.ClientSize.Height - formApagarArea.Height) / 3);
            formApagarArea.Show();
            formApagarArea.Activate();
        }

        //listar formadores
        private void listarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
             //verifica se o form foi eliminado, caso sim, instancia novamente
            if (formListarFormadores.IsDisposed)
            {
                formListarFormadores = new FormListarFormadores(); ;
            }
            formListarFormadores.MdiParent = this;
            // posicionar o form no ecrã
            formListarFormadores.StartPosition = FormStartPosition.Manual;
            formListarFormadores.Location = new Point((this.ClientSize.Width - formListarFormadores.Width) / 2,
                                            (this.ClientSize.Height - formListarFormadores.Height) / 3);
            formListarFormadores.Show();
            formListarFormadores.Activate();
        }

        //listar áreas
        private void listarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //verifica se o form foi eliminado, caso sim, instancia novamente
            if (formListarAreas.IsDisposed)
            {
                formListarAreas = new FormListarAreas(); ;
            }
            formListarAreas.MdiParent = this;
            // posicionar o form no ecrã
            formListarAreas.StartPosition = FormStartPosition.Manual;
            formListarAreas.Location = new Point((this.ClientSize.Width - formListarAreas.Width) / 2,
                                            (this.ClientSize.Height - formListarAreas.Height) / 3);
            formListarAreas.Show();
            formListarAreas.Activate();
        }
    }
    
}
