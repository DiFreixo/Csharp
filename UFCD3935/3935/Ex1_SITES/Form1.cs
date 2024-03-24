using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Elaborado por Diana Freixo

namespace Ex1_SITES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            webBrowser1.Navigate("https://www.fca.pt");
            linkLabel1.VisitedLinkColor = System.Drawing.Color.Blue;
            linkLabel1.ActiveLinkColor = System.Drawing.Color.Green;
            linkLabel1.LinkColor = System.Drawing.Color.Navy;

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            webBrowser1.Navigate("https://www.microsoft.com");
            linkLabel2.VisitedLinkColor = System.Drawing.Color.Blue;
            linkLabel2.ActiveLinkColor = System.Drawing.Color.Green;
            linkLabel2.LinkColor = System.Drawing.Color.Navy;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com");
            linkLabel3.VisitedLinkColor = System.Drawing.Color.Blue;
            linkLabel3.ActiveLinkColor = System.Drawing.Color.Green;
            linkLabel3.LinkColor = System.Drawing.Color.Navy;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int larguraForm;
            larguraForm = this.Width;
            splitContainer1.Panel1MinSize = 300;
            splitContainer1.Panel2MinSize = larguraForm - splitContainer1.Panel1MinSize;
            label1.ForeColor = Color.Blue;
            label1.Font = new Font(label1.Font,FontStyle.Underline);
            label2.ForeColor = Color.Blue;
            label2.Font = new Font(label1.Font, FontStyle.Underline);
            label3.ForeColor = Color.Blue;
            label3.Font = new Font(label1.Font, FontStyle.Underline);
        }

        private void linkLabel1_MouseMove(object sender, MouseEventArgs e)
        {
            linkLabel1.BackColor = System.Drawing.Color.Orange;
        }

        private void linkLabel2_MouseMove(object sender, MouseEventArgs e)
        {
            linkLabel2.BackColor = System.Drawing.Color.Orange;
        }

        private void linkLabel3_MouseMove(object sender, MouseEventArgs e)
        {
            linkLabel3.BackColor = System.Drawing.Color.Orange;
        }


        private void splitContainer1_Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            linkLabel1.BackColor = System.Drawing.Color.Transparent;
            linkLabel2.BackColor = System.Drawing.Color.Transparent;
            linkLabel3.BackColor = System.Drawing.Color.Transparent;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.fca.pt");
            label1.ForeColor = Color.Navy;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.microsoft.com");
            label2.ForeColor = Color.Navy;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com");
            label3.ForeColor = Color.Navy;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.BackColor = Color.Orange;
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            label2.BackColor = Color.Orange;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            label3.BackColor = Color.Orange;
        }
    }
}
