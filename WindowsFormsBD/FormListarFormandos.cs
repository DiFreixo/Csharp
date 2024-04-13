using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsBD
{
    public partial class FormListarFormandos : Form
    {
        DBConnect ligacao = new DBConnect();
        int id_nacionalidade = 0;
        public FormListarFormandos()
        {
            InitializeComponent();
        }

        private void FormListarFormandos_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Columns.Add("codID", "ID");
            dataGridView1.Columns.Add("Nome", "Nome");
            dataGridView1.Columns.Add("Iban", "Iban");
            //dataGridView1.Columns.Add("Contacto", "Contacto");
            dataGridView1.Columns.Add("Nacionalidade", "Nacionalidade");
            dataGridView1.Columns.Add("Genero", "Género");
            

            //ligacao.PreencherDataGridViewFormandos(ref dataGridView1);
            ligacao.PreencherDataGridViewFormandosPesquisa(ref dataGridView1, "",genero(), "");

            lblRegistos.Text = "Nº Registos: " + dataGridView1.RowCount.ToString();

            rbTodos.Checked = true;
            ligacao.PreencherComboboxNacionalidade(ref cmbNacionalidade);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            txtNome.Text = "";
            cmbNacionalidade.SelectedIndex = -1;
            rbTodos.Checked = true;
            //ligacao.PreencherDataGridViewFormandos(ref dataGridView1);
            ligacao.PreencherDataGridViewFormandosPesquisa(ref dataGridView1, "", genero(), "");

            lblRegistos.Text = "Nº Registos: " + dataGridView1.RowCount.ToString();

            
        }


        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            string id_nacionalidade = "";

            dataGridView1.Rows.Clear();

            if (cmbNacionalidade.SelectedIndex != -1)
            {
                id_nacionalidade = cmbNacionalidade.Text.Substring(cmbNacionalidade.Text.LastIndexOf(' ') + 1);
            }
            string nome = Geral.removerEspacos(txtNome.Text);
            ligacao.PreencherDataGridViewFormandosPesquisa(ref dataGridView1, nome, genero(), id_nacionalidade);

            lblRegistos.Text = "Nº Registos: " + dataGridView1.RowCount.ToString();


            /*
            string nome = txtNome.Text.Trim();
            char genero = 'T';
            dataGridView1.Rows.Clear();

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

            ligacao.PreencherDataGridViewFormandosPesquisa(ref dataGridView1, ref nome, ref genero);
            lblRegistos.Text = "Nº Registos: " + dataGridView1.RowCount.ToString();
            */
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

       
        private void cmbNacionalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
                // Verifica se algum item está selecionado
                if (cmbNacionalidade.SelectedIndex >= 0) // != -1
                {
                    id_nacionalidade = int.Parse(ExtrairIdNacionalidade(cmbNacionalidade.Text));
                }
        }


        // Método para extrair a nacionalidade e o id_nacionalidade da string nacionalidadeCombo
        private string ExtrairIdNacionalidade(string nacionalidadeCombo)
        {
            string idNacionalidade = nacionalidadeCombo.Substring(nacionalidadeCombo.LastIndexOf(' ') + 1);
            return (idNacionalidade);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Formandos.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Impossível de apagar o ficheiro!");
                        }
                    }
                    //if (!fileError == true)
                    //if (fileError == false)
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfPTable = new PdfPTable(dataGridView1.Columns.Count);
                            pdfPTable.DefaultCell.Padding = 3;
                            pdfPTable.WidthPercentage = 100;
                            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfPTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfPTable.AddCell(cell.Value.ToString());
                                }
                            }

                            //using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))

                            FileStream stream = new FileStream(sfd.FileName, FileMode.Create);
                            //{
                            Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();
                            pdfDoc.Add(pdfPTable);
                            pdfDoc.Close();
                            stream.Close();
                            //}

                            MessageBox.Show("Imprimiu com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Não existe registos!");
            }
        }


    }
}
