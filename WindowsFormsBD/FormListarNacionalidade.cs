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

    public partial class FormListarNacionalidade : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormListarNacionalidade()
        {
            InitializeComponent();
        }

        private void FormListarNacionalidade_Load(object sender, EventArgs e)
        {
            dataGridViewNacionalidade.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewNacionalidade.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewNacionalidade.AllowUserToAddRows = false;
            dataGridViewNacionalidade.AllowUserToDeleteRows = false;
            dataGridViewNacionalidade.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewNacionalidade.Columns.Add("codID", "Registo");
            dataGridViewNacionalidade.Columns.Add("ALF2", "ALF2");
            dataGridViewNacionalidade.Columns.Add("Nacionalidade", "Nacionalidade");

            ligacao.PreencherDataGridViewNacionalidade(ref dataGridViewNacionalidade);

            lblRegistos.Text = "Nº Registos: " + dataGridViewNacionalidade.RowCount.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridViewNacionalidade.Rows.Clear();
            ligacao.PreencherDataGridViewNacionalidade(ref dataGridViewNacionalidade);

            lblRegistos.Text = "Nº Registos: " + dataGridViewNacionalidade.RowCount.ToString();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dataGridViewNacionalidade.Rows.Count > 0)
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
                            PdfPTable pdfPTable = new PdfPTable(dataGridViewNacionalidade.Columns.Count);
                            pdfPTable.DefaultCell.Padding = 3;
                            pdfPTable.WidthPercentage = 100;
                            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridViewNacionalidade.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfPTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridViewNacionalidade.Rows)
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
