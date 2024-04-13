namespace WindowsFormsBD
{
    partial class FormInserirFormandos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbNacionalidade = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mtxtContacto = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.mtxtDataNascimento = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rbOutro = new System.Windows.Forms.RadioButton();
            this.rbMasculino = new System.Windows.Forms.RadioButton();
            this.rbFeminino = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.mtxtIban = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMorada = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.numUDid = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbNacionalidade);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.mtxtContacto);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.mtxtDataNascimento);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.rbOutro);
            this.groupBox1.Controls.Add(this.rbMasculino);
            this.groupBox1.Controls.Add(this.rbFeminino);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.mtxtIban);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMorada);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.numUDid);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(29, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 531);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbNacionalidade
            // 
            this.cmbNacionalidade.FormattingEnabled = true;
            this.cmbNacionalidade.Location = new System.Drawing.Point(177, 471);
            this.cmbNacionalidade.Name = "cmbNacionalidade";
            this.cmbNacionalidade.Size = new System.Drawing.Size(328, 28);
            this.cmbNacionalidade.TabIndex = 18;
            this.cmbNacionalidade.SelectedIndexChanged += new System.EventHandler(this.cmbNacionalidade_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 474);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Nacionalidade:";
            // 
            // mtxtContacto
            // 
            this.mtxtContacto.Location = new System.Drawing.Point(177, 242);
            this.mtxtContacto.Mask = "000 000 000";
            this.mtxtContacto.Name = "mtxtContacto";
            this.mtxtContacto.Size = new System.Drawing.Size(323, 26);
            this.mtxtContacto.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(288, 411);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(212, 26);
            this.dateTimePicker1.TabIndex = 16;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // mtxtDataNascimento
            // 
            this.mtxtDataNascimento.Location = new System.Drawing.Point(177, 411);
            this.mtxtDataNascimento.Mask = "00/00/0000";
            this.mtxtDataNascimento.Name = "mtxtDataNascimento";
            this.mtxtDataNascimento.Size = new System.Drawing.Size(100, 26);
            this.mtxtDataNascimento.TabIndex = 15;
            this.mtxtDataNascimento.ValidatingType = typeof(System.DateTime);
            this.mtxtDataNascimento.TextChanged += new System.EventHandler(this.mtxtDataNascimento_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 414);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Data Nascimento:";
            // 
            // rbOutro
            // 
            this.rbOutro.AutoSize = true;
            this.rbOutro.Location = new System.Drawing.Point(426, 361);
            this.rbOutro.Name = "rbOutro";
            this.rbOutro.Size = new System.Drawing.Size(74, 24);
            this.rbOutro.TabIndex = 13;
            this.rbOutro.TabStop = true;
            this.rbOutro.Text = "Outro";
            this.rbOutro.UseVisualStyleBackColor = true;
            // 
            // rbMasculino
            // 
            this.rbMasculino.AutoSize = true;
            this.rbMasculino.Location = new System.Drawing.Point(277, 361);
            this.rbMasculino.Name = "rbMasculino";
            this.rbMasculino.Size = new System.Drawing.Size(105, 24);
            this.rbMasculino.TabIndex = 12;
            this.rbMasculino.TabStop = true;
            this.rbMasculino.Text = "Masculino";
            this.rbMasculino.UseVisualStyleBackColor = true;
            // 
            // rbFeminino
            // 
            this.rbFeminino.AutoSize = true;
            this.rbFeminino.Location = new System.Drawing.Point(172, 361);
            this.rbFeminino.Name = "rbFeminino";
            this.rbFeminino.Size = new System.Drawing.Size(99, 24);
            this.rbFeminino.TabIndex = 11;
            this.rbFeminino.TabStop = true;
            this.rbFeminino.Text = "Feminino";
            this.rbFeminino.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 361);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Sexo:";
            // 
            // mtxtIban
            // 
            this.mtxtIban.Location = new System.Drawing.Point(177, 303);
            this.mtxtIban.Mask = "AA00000000000000000000000";
            this.mtxtIban.Name = "mtxtIban";
            this.mtxtIban.Size = new System.Drawing.Size(323, 26);
            this.mtxtIban.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "IBAN:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contacto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Morada:";
            // 
            // txtMorada
            // 
            this.txtMorada.Location = new System.Drawing.Point(177, 181);
            this.txtMorada.MaxLength = 100;
            this.txtMorada.Name = "txtMorada";
            this.txtMorada.Size = new System.Drawing.Size(323, 26);
            this.txtMorada.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(177, 121);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(323, 26);
            this.txtNome.TabIndex = 3;
            // 
            // numUDid
            // 
            this.numUDid.Location = new System.Drawing.Point(177, 68);
            this.numUDid.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numUDid.Name = "numUDid";
            this.numUDid.Size = new System.Drawing.Size(167, 26);
            this.numUDid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnGravar);
            this.groupBox2.Location = new System.Drawing.Point(29, 575);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 90);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancelar.Location = new System.Drawing.Point(389, 25);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 42);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.BackColor = System.Drawing.Color.Gray;
            this.btnGravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGravar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnGravar.Location = new System.Drawing.Point(95, 25);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(111, 42);
            this.btnGravar.TabIndex = 0;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = false;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // FormInserirFormandos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(648, 689);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInserirFormandos";
            this.Text = "Registar Formandos";
            this.Load += new System.EventHandler(this.FormInserirFormandos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numUDid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mtxtIban;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMorada;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbOutro;
        private System.Windows.Forms.RadioButton rbMasculino;
        private System.Windows.Forms.RadioButton rbFeminino;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.MaskedTextBox mtxtDataNascimento;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.MaskedTextBox mtxtContacto;
        private System.Windows.Forms.ComboBox cmbNacionalidade;
        private System.Windows.Forms.Label label8;
    }
}