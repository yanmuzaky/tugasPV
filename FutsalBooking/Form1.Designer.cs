namespace FutsalBooking
{
    partial class Form1
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
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.cbLapangan = new System.Windows.Forms.ComboBox();
            this.dtTanggal = new System.Windows.Forms.DateTimePicker();
            this.dtJam = new System.Windows.Forms.DateTimePicker();
            this.btnBook = new System.Windows.Forms.Button();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lapangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBookings
            // 
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nama,
            this.Lapangan,
            this.Tanggal,
            this.Jam});
            this.dgvBookings.Location = new System.Drawing.Point(13, 13);
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.Size = new System.Drawing.Size(475, 322);
            this.dgvBookings.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nama";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(520, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lapangan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tanggal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(520, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Jam";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(588, 41);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(100, 20);
            this.txtNama.TabIndex = 5;
            // 
            // cbLapangan
            // 
            this.cbLapangan.FormattingEnabled = true;
            this.cbLapangan.Items.AddRange(new object[] {
            "Lapangan 1",
            "Lapangan 2",
            "Lapangan 3"});
            this.cbLapangan.Location = new System.Drawing.Point(588, 82);
            this.cbLapangan.Name = "cbLapangan";
            this.cbLapangan.Size = new System.Drawing.Size(121, 21);
            this.cbLapangan.TabIndex = 6;
            this.cbLapangan.Text = "Pilih Lapangan";
            // 
            // dtTanggal
            // 
            this.dtTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTanggal.Location = new System.Drawing.Point(588, 124);
            this.dtTanggal.Name = "dtTanggal";
            this.dtTanggal.Size = new System.Drawing.Size(130, 20);
            this.dtTanggal.TabIndex = 7;
            // 
            // dtJam
            // 
            this.dtJam.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtJam.Location = new System.Drawing.Point(588, 167);
            this.dtJam.Name = "dtJam";
            this.dtJam.Size = new System.Drawing.Size(83, 20);
            this.dtJam.TabIndex = 8;
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(546, 225);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(77, 26);
            this.btnBook.TabIndex = 9;
            this.btnBook.Text = "Booking";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.button1_Click);
            // 
            // Nama
            // 
            this.Nama.HeaderText = "Nama";
            this.Nama.Name = "Nama";
            // 
            // Lapangan
            // 
            this.Lapangan.HeaderText = "Lapangan";
            this.Lapangan.Name = "Lapangan";
            // 
            // Tanggal
            // 
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            // 
            // Jam
            // 
            this.Jam.HeaderText = "Jam";
            this.Jam.Name = "Jam";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.dtJam);
            this.Controls.Add(this.dtTanggal);
            this.Controls.Add(this.cbLapangan);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBookings);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.ComboBox cbLapangan;
        private System.Windows.Forms.DateTimePicker dtTanggal;
        private System.Windows.Forms.DateTimePicker dtJam;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lapangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jam;
    }
}

