namespace arackiralama
{
    partial class rezerve
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rezerve));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bitis = new System.Windows.Forms.DateTimePicker();
            this.cbekle = new System.Windows.Forms.ComboBox();
            this.cbplaka = new System.Windows.Forms.ComboBox();
            this.tbucret = new System.Windows.Forms.TextBox();
            this.tbbasla = new System.Windows.Forms.DateTimePicker();
            this.tbtc = new System.Windows.Forms.TextBox();
            this.tbsk = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.aranan = new System.Windows.Forms.TextBox();
            this.rbhepsi = new System.Windows.Forms.RadioButton();
            this.rbbtc = new System.Windows.Forms.RadioButton();
            this.rbplaka = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(547, 328);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 81);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(12, 247);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(526, 171);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "kkodu";
            this.Column6.HeaderText = "Kira Kodu";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "tckimlik";
            this.Column1.HeaderText = "Tc Kimlik No";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "plaka";
            this.Column2.HeaderText = "Araç Plaka";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "basla";
            this.Column3.HeaderText = "Başlangıç Tarihi";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "bitis";
            this.Column4.HeaderText = "Bitiş Tarihi";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ucret";
            this.Column5.HeaderText = "Ücret";
            this.Column5.Name = "Column5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Bernard MT Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(161, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rezerve Edilmiş Araçlar";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.bitis);
            this.groupBox1.Controls.Add(this.cbekle);
            this.groupBox1.Controls.Add(this.cbplaka);
            this.groupBox1.Controls.Add(this.tbucret);
            this.groupBox1.Controls.Add(this.tbbasla);
            this.groupBox1.Controls.Add(this.tbtc);
            this.groupBox1.Controls.Add(this.tbsk);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(11, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 198);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rezerve Edilen Araçlar";
            // 
            // bitis
            // 
            this.bitis.Location = new System.Drawing.Point(126, 133);
            this.bitis.Name = "bitis";
            this.bitis.Size = new System.Drawing.Size(135, 23);
            this.bitis.TabIndex = 19;
            this.bitis.ValueChanged += new System.EventHandler(this.bitis_ValueChanged);
            // 
            // cbekle
            // 
            this.cbekle.Enabled = false;
            this.cbekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbekle.FormattingEnabled = true;
            this.cbekle.Location = new System.Drawing.Point(126, 135);
            this.cbekle.Name = "cbekle";
            this.cbekle.Size = new System.Drawing.Size(121, 15);
            this.cbekle.TabIndex = 3;
            // 
            // cbplaka
            // 
            this.cbplaka.FormattingEnabled = true;
            this.cbplaka.Location = new System.Drawing.Point(126, 79);
            this.cbplaka.Name = "cbplaka";
            this.cbplaka.Size = new System.Drawing.Size(135, 24);
            this.cbplaka.TabIndex = 18;
            // 
            // tbucret
            // 
            this.tbucret.Enabled = false;
            this.tbucret.Location = new System.Drawing.Point(126, 164);
            this.tbucret.Name = "tbucret";
            this.tbucret.Size = new System.Drawing.Size(135, 23);
            this.tbucret.TabIndex = 17;
            // 
            // tbbasla
            // 
            this.tbbasla.Location = new System.Drawing.Point(126, 106);
            this.tbbasla.MinDate = new System.DateTime(2019, 5, 1, 0, 0, 0, 0);
            this.tbbasla.Name = "tbbasla";
            this.tbbasla.Size = new System.Drawing.Size(135, 23);
            this.tbbasla.TabIndex = 15;
            this.tbbasla.Value = new System.DateTime(2019, 5, 1, 0, 0, 0, 0);
            // 
            // tbtc
            // 
            this.tbtc.Location = new System.Drawing.Point(126, 51);
            this.tbtc.Name = "tbtc";
            this.tbtc.Size = new System.Drawing.Size(135, 23);
            this.tbtc.TabIndex = 13;
            // 
            // tbsk
            // 
            this.tbsk.Enabled = false;
            this.tbsk.Location = new System.Drawing.Point(126, 24);
            this.tbsk.Name = "tbsk";
            this.tbsk.Size = new System.Drawing.Size(135, 23);
            this.tbsk.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bernard MT Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(10, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Ücret:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bernard MT Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(10, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Bitiş Tarihi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bernard MT Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(7, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Başlangıç Tarihi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bernard MT Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(10, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Araç Plaka:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bernard MT Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(10, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Tc Kimlik No:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bernard MT Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(10, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Satış Kodu:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.aranan);
            this.groupBox2.Controls.Add(this.rbhepsi);
            this.groupBox2.Controls.Add(this.rbbtc);
            this.groupBox2.Controls.Add(this.rbplaka);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(301, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 199);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bul Ve Göster";
            // 
            // aranan
            // 
            this.aranan.Location = new System.Drawing.Point(73, 28);
            this.aranan.Name = "aranan";
            this.aranan.Size = new System.Drawing.Size(140, 23);
            this.aranan.TabIndex = 6;
            this.aranan.TextChanged += new System.EventHandler(this.aranan_TextChanged_1);
            // 
            // rbhepsi
            // 
            this.rbhepsi.AutoSize = true;
            this.rbhepsi.Location = new System.Drawing.Point(18, 66);
            this.rbhepsi.Name = "rbhepsi";
            this.rbhepsi.Size = new System.Drawing.Size(155, 21);
            this.rbhepsi.TabIndex = 5;
            this.rbhepsi.TabStop = true;
            this.rbhepsi.Text = "Tüm Kayıtları Göster";
            this.rbhepsi.UseVisualStyleBackColor = true;
            this.rbhepsi.Click += new System.EventHandler(this.rbhepsi_Click);
            // 
            // rbbtc
            // 
            this.rbbtc.AutoSize = true;
            this.rbbtc.Location = new System.Drawing.Point(18, 120);
            this.rbbtc.Name = "rbbtc";
            this.rbbtc.Size = new System.Drawing.Size(82, 21);
            this.rbbtc.TabIndex = 5;
            this.rbbtc.TabStop = true;
            this.rbbtc.Text = "Tc Kimlik";
            this.rbbtc.UseVisualStyleBackColor = true;
            // 
            // rbplaka
            // 
            this.rbplaka.AutoSize = true;
            this.rbplaka.Location = new System.Drawing.Point(19, 93);
            this.rbplaka.Name = "rbplaka";
            this.rbplaka.Size = new System.Drawing.Size(61, 21);
            this.rbplaka.TabIndex = 5;
            this.rbplaka.TabStop = true;
            this.rbplaka.Text = "Plaka";
            this.rbplaka.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bernard MT Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(155, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Raporla";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::arackiralama.Properties.Resources.Document_black_256;
            this.pictureBox2.Location = new System.Drawing.Point(143, 93);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(75, 77);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bernard MT Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(16, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Ara:";
            // 
            // rezerve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(193)))), ((int)(((byte)(203)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(629, 421);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "rezerve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "rezerve";
            this.Load += new System.EventHandler(this.rezerve_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbplaka;
        private System.Windows.Forms.TextBox tbucret;
        private System.Windows.Forms.DateTimePicker tbbasla;
        private System.Windows.Forms.TextBox tbtc;
        private System.Windows.Forms.TextBox tbsk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.ComboBox cbekle;
        private System.Windows.Forms.DateTimePicker bitis;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbhepsi;
        private System.Windows.Forms.RadioButton rbbtc;
        private System.Windows.Forms.RadioButton rbplaka;
        private System.Windows.Forms.TextBox aranan;
    }
}