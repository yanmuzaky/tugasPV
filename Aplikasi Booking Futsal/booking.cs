using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Aplikasi_Booking_Futsal
{
    public partial class booking : Form
    {
        Koneksi koneksi;
        public main MainForm;
        private bool isEdit = false; // <- Tambah ini
        private int bookingId;       // <- Ini buat tau ID booking yang diedit

        // Constructor untuk Insert Data (baru)
        public booking()
        {
            InitializeComponent();
        }

        // Constructor untuk Edit Data
        public booking(int id, string nama, string lapangan, DateTime tglBooking, DateTime tglMain, TimeSpan jamMain, string durasi)
        {
            InitializeComponent();

            isEdit = true; // <- tandain ini edit mode
            bookingId = id; // <- simpan ID untuk update

            // Isi form
            namaTxt.Text = nama;
            durasiTxt.Text = durasi;
            tglBook_dt.Value = tglBooking;
            tglMain_dt.Value = tglMain;
            jamMulai_dt.Value = DateTime.Today.Add(jamMain);

            if (lapangan == "Lap 1")
                radioButton1.Checked = true;
            else if (lapangan == "Lap 2")
                radioButton2.Checked = true;
        }

        private void booking_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            if (isEdit)
                button1.Text = "Update"; 
            else
                button1.Text = "Submit"; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            koneksi = new Koneksi();
            try
            {
                string nama = namaTxt.Text;
                string tanggalMain = tglMain_dt.Value.ToString("yyyy-MM-dd");
                string jamMulai = jamMulai_dt.Value.ToString("HH:mm:ss");
                string tanggalBooking = tglBook_dt.Value.ToString("yyyy-MM-dd");
                string durasi = durasiTxt.Text;

                string lapangan = "";
                if (radioButton1.Checked)
                    lapangan = "Lap 1";
                else if (radioButton2.Checked)
                    lapangan = "Lap 2";

                koneksi.buka();
                MySqlCommand sql = new MySqlCommand();
                sql.Connection = koneksi.koneksi;
                sql.CommandType = CommandType.Text;

                if (isEdit)
                {
                    // jika Update
                    sql.CommandText = "UPDATE booking SET nama = '" + nama + "', lapangan = '" + lapangan + "', " +
                                      "tgl_booking = '" + tanggalBooking + "', tgl_main = '" + tanggalMain + "', " +
                                      "jam_main = '" + jamMulai + "', durasi = '" + durasi + "' WHERE id_boking = " + bookingId;
                }
                else
                {
                    // jika Insert
                    sql.CommandText = "INSERT INTO booking (nama, lapangan, tgl_booking, tgl_main, jam_main, durasi) " +
                                      "VALUES ('" + nama + "', '" + lapangan + "', '" + tanggalBooking + "', '" + tanggalMain + 
                                      "', '" + jamMulai + "', '" + durasi + "')";
                }

                sql.ExecuteNonQuery();
                koneksi.tutup();

                MessageBox.Show(isEdit ? "Data Berhasil Diupdate" : "Data Berhasil Ditambahkan");

                ResetForm();
                MainForm.showDashboard();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show((isEdit ? "Update" : "Tambah") + " Gagal : " + ex.Message);
            }
        }

        private void ResetForm()
        {
            namaTxt.Clear();
            durasiTxt.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            tglMain_dt.Value = DateTime.Now;
            tglBook_dt.Value = DateTime.Now;
            jamMulai_dt.Value = DateTime.Now;
        }
    }

}
