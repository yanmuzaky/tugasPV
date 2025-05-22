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
using Aplikasi_Booking_Futsal.Controller;
using Aplikasi_Booking_Futsal.Model;
using MySql.Data.MySqlClient;

namespace Aplikasi_Booking_Futsal
{
    public partial class booking : Form
    {
        public main MainForm;
        private bool isEdit = false;
        private int bookingId;
        bookingController controller = new bookingController();

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
            button1.Text = isEdit ? "Update" : "Submit";
        }

        private Booking AmbilDataForm()
        {
            return new Booking
            {
                Id = bookingId,
                Nama = namaTxt.Text,
                Lapangan = radioButton1.Checked ? "Lap 1" : "Lap 2",
                TglBooking = tglBook_dt.Value.ToString("yyyy-MM-dd"),
                TglMain = tglMain_dt.Value.ToString("yyyy-MM-dd"),
                JamMain = jamMulai_dt.Value.ToString("HH:mm:ss"),
                Durasi = durasiTxt.Text
            };
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Booking booking = new Booking
                //{
                //    Id = bookingId,
                //    Nama = namaTxt.Text,
                //    Lapangan = radioButton1.Checked ? "Lap 1" : "Lap 2",
                //    TglBooking = tglBook_dt.Value.ToString("yyyy-MM-dd"),
                //    TglMain = tglMain_dt.Value.ToString("yyyy-MM-dd"),
                //    JamMain = jamMulai_dt.Value.ToString("HH:mm:ss"),
                //    Durasi = durasiTxt.Text
                //};
                Booking b = AmbilDataForm();
                bool result;
                if (isEdit)
                {
                    result = controller.UpdateBooking(b);  // edit data
                }
                else
                {
                    result = controller.AddBooking(b);     // tambah data
                }

                if (result)
                {
                    MessageBox.Show(isEdit ? "Data berhasil diupdate." : "Data berhasil ditambahkan.");
                    ResetForm();
                    MainForm.showDashboard();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
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
