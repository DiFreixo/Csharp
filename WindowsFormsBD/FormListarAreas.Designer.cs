namespace WindowsFormsBD
{
    partial class FormListarAreas
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
            this.dataGridViewArea = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArea)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Gray;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnImprimir.Location = new System.Drawing.Point(217, 86);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(111, 42);
            this.btnImprimir.TabIndex = 1;
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
            this.btnRefresh.Location = new System.Drawing.Point(352, 86);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(111, 42);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblRegistos
            // 
            this.lblRegistos.AutoSize = true;
            this.lblRegistos.Location = new System.Drawing.Point(16, 40);
            this.lblRegistos.Name = "lblRegistos";
            this.lblRegistos.Size = new System.Drawing.Size(97, 20);
            this.lblRegistos.TabIndex = 0;
            this.lblRegistos.Text = "Nº Registos:";
            // 
            // dataGridViewArea
            // 
            this.dataGridViewArea.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArea.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewArea.Name = "dataGridViewArea";
            this.dataGridViewArea.RowHeadersWidth = 62;
            this.dataGridViewArea.RowTemplate.Height = 28;
            this.dataGridViewArea.Size = new System.Drawing.Size(478, 498);
            this.dataGridViewArea.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRegistos);
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Location = new System.Drawing.Point(12, 516);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 143);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // FormListarAreas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(501, 672);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormListarAreas";
            this.Text = "Listar Áreas";
            this.Load += new System.EventHandler(this.FormListarAreas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArea)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblRegistos;
        private System.Windows.Forms.DataGridView dataGridViewArea;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}