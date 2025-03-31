using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutsalBooking
{
    public partial class Form1 : Form
    {
        private string filePath = "bookings.csv";  // File penyimpanan lokal

        public Form1()
        {
            InitializeComponent();
            LoadBookings();
        }
        private void btnBook_Click(object sender, EventArgs e)
        {
            string nama = txtNama.Text;
            string lapangan = cbLapangan.Text;
            string tanggal = dtTanggal.Value.ToShortDateString();
            string jam = dtJam.Value.ToShortTimeString();

            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(lapangan))
            {
                MessageBox.Show("Harap isi semua data!");
                return;
            }

            // Format data booking
            string bookingData = $"{nama},{lapangan},{tanggal},{jam}";

            try
            {
                // Pastikan file bisa ditulis
                File.AppendAllText(filePath, bookingData + Environment.NewLine);

                MessageBox.Show("Booking berhasil!");

                LoadBookings();  // Tampilkan data terbaru di DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadBookings()
        {
            dgvBookings.Rows.Clear();  // Hapus data lama

            if (File.Exists(filePath))  // Pastikan file CSV ada
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] data = line.Split(',');  // Pisahkan data dengan koma

                    if (data.Length == 4)  // Pastikan format data benar
                    {
                        dgvBookings.Rows.Add(data);
                    }
                }
            }
            else
            {
                MessageBox.Show("File bookings.csv tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button1 diklik!");
        }
    }
}
