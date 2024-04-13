using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsBD
{
    public partial class FormListarFormadores : Form
    {
        DBConnect ligacao = new DBConnect();
        int id_area = 0;
        public FormListarFormadores()
        {
            InitializeComponent();
        }

        private void FormListarFormadores_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Columns.Add("codID", "ID");
            dataGridView1.Columns.Add("Nome", "Nome");
            dataGridView1.Columns.Add("Nif", "NIF");
            dataGridView1.Columns.Add("Area", "Área");

            ligacao.PreencherDataGridViewFormadoresPesquisa(ref dataGridView1, "", ""); 

            lblRegistos.Text = "Nº Registos: " + dataGridView1.RowCount.ToString();
            ligacao.PreencherComboboxArea(ref cmbArea);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            txtNome.Text = "";
            cmbArea.SelectedIndex = -1;
            ligacao.PreencherDataGridViewFormadoresPesquisa(ref dataGridView1, "", ""); 

            lblRegistos.Text = "Nº Registos: " + dataGridView1.RowCount.ToString();

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            string id_area = "";

            dataGridView1.Rows.Clear();

            if (cmbArea.SelectedIndex != -1)
            {
                id_area = cmbArea.Text.Substring(0, cmbArea.Text.IndexOf(" -"));
            }
            string nome = Geral.removerEspacos(txtNome.Text);
            ligacao.PreencherDataGridViewFormadoresPesquisa(ref dataGridView1, nome, id_area); 

            lblRegistos.Text = "Nº Registos: " + dataGridView1.RowCount.ToString();
        }

        
        private void cmbArea_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Verifica se algum item está selecionado
            if (cmbArea.SelectedIndex >= 0) // != -1
            {
                id_area = int.Parse(ExtrairIdArea(cmbArea.Text));
            }
        }

        private string ExtrairIdArea(string areaCombo)
        {

            string idArea = areaCombo.Substring(0, areaCombo.IndexOf(" -"));

            return idArea;

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Formadores.pdf";
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
