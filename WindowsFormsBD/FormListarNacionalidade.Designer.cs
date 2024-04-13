namespace WindowsFormsBD
{
    partial class FormListarNacionalidade
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblRegistos = new System.Windows.Forms.Label();
            this.dataGridViewNacionalidade = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNacionalidade)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Gray;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnImprimir.Location = new System.Drawing.Point(243, 574);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(111, 42);
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseMnemonic = false;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Gray;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRefresh.Location = new System.Drawing.Point(380, 574);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(111, 42);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblRegistos
            // 
            this.lblRegistos.AutoSize = true;
            this.lblRegistos.Location = new System.Drawing.Point(12, 536);
            this.lblRegistos.Name = "lblRegistos";
            this.lblRegistos.Size = new System.Drawing.Size(97, 20);
            this.lblRegistos.TabIndex = 9;
            this.lblRegistos.Text = "Nº Registos:";
            // 
            // dataGridViewNacionalidade
            // 
            this.dataGridViewNacionalidade.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewNacionalidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNacionalidade.Location = new System.Drawing.Point(13, 12);
            this.dataGridViewNacionalidade.Name = "dataGridViewNacionalidade";
            this.dataGridViewNacionalidade.RowHeadersWidth = 62;
            this.dataGridViewNacionalidade.RowTemplate.Height = 28;
            this.dataGridViewNacionalidade.Size = new System.Drawing.Size(478, 498);
            this.dataGridViewNacionalidade.TabIndex = 8;
            // 
            // FormListarNacionalidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(507, 633);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblRegistos);
            this.Controls.Add(this.dataGridViewNacionalidade);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormListarNacionalidade";
            this.Text = "Listar Nacionalidade";
            this.Load += new System.EventHandler(this.FormListarNacionalidade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNacionalidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblRegistos;
        private System.Windows.Forms.DataGridView dataGridViewNacionalidade;
    }
}