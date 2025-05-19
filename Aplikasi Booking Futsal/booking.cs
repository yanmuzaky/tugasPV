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
        private bool isEdit = false; 
        private int bookingId;       

        public booking()
        {
            InitializeComponent();
        }

        public booking(int id, string nama, string lapangan, DateTime tglBooking, DateTime tglMain, TimeSpan jamMain, string durasi)
        {
            InitializeComponent();

            isEdit = true; 
            bookingId = id; 

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
                string lapangan = radioButton1.Checked ? "Lap 1" : "Lap 2";

                bookingCRUD bookingCrud = new bookingCRUD();

                if (isEdit)
                {
                    // jika Update
                    bookingCrud.UpdateBooking(bookingId, nama, lapangan, tanggalBooking, tanggalMain, jamMulai, durasi);
                    MessageBox.Show("Data Berhasil Diupdate");
                }
                else
                {
                    // jika Insert
                    bookingCrud.TambahBooking(nama, lapangan, tanggalBooking, tanggalMain, jamMulai, durasi);
                    MessageBox.Show("Data Berhasil Ditambahkan");
                }

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
