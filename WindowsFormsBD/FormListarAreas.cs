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
    public partial class FormListarAreas : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormListarAreas()
        {
            InitializeComponent();
        }

        private void FormListarAreas_Load(object sender, EventArgs e)
        {
            dataGridViewArea.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewArea.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewArea.AllowUserToAddRows = false;
            dataGridViewArea.AllowUserToDeleteRows = false;
            dataGridViewArea.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewArea.Columns.Add("codID", "Registo");
            dataGridViewArea.Columns.Add("Area", "Área");

            ligacao.PreencherdataGridViewArea(ref dataGridViewArea);

            lblRegistos.Text = "Nº Registos: " + dataGridViewArea.RowCount.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridViewArea.Rows.Clear();
            ligacao.PreencherdataGridViewArea(ref dataGridViewArea);

            lblRegistos.Text = "Nº Registos: " + dataGridViewArea.RowCount.ToString();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dataGridViewArea.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Areas.pdf";
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
                            PdfPTable pdfPTable = new PdfPTable(dataGridViewArea.Columns.Count);
                            pdfPTable.DefaultCell.Padding = 3;
                            pdfPTable.WidthPercentage = 100;
                            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridViewArea.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfPTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridViewArea.Rows)
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
