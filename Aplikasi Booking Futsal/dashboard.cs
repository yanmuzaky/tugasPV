using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Aplikasi_Booking_Futsal
{
    public partial class dashboard : Form
    {
        Koneksi koneksi;
        booking booking;
        public main MainForm;


        public dashboard()
        {
            InitializeComponent();

        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            LoadData();

        }

        public void LoadData()
        {
            koneksi = new Koneksi();
            DataSet ds = new DataSet();
            DataTable dt;

            koneksi.buka();
            var con = koneksi.koneksi;

            string sql = "select * from booking";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            koneksi.tutup();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_boking"].Value);
                string nama = dataGridView1.SelectedRows[0].Cells["nama"].Value.ToString();
                string lapangan = dataGridView1.SelectedRows[0].Cells["lapangan"].Value.ToString();
                DateTime tglBooking = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["tgl_booking"].Value);
                DateTime tglMain = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["tgl_main"].Value);
                TimeSpan jamMain = TimeSpan.Parse(dataGridView1.SelectedRows[0].Cells["jam_main"].Value.ToString());
                string durasi = dataGridView1.SelectedRows[0].Cells["durasi"].Value.ToString();

                booking editBooking = new booking(id, nama, lapangan, tglBooking, tglMain, jamMain, durasi);
                editBooking.MainForm = this.MainForm;
                editBooking.MdiParent = this.MdiParent;
                editBooking.Dock = DockStyle.Fill;
                editBooking.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin diedit dulu!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_boking"].Value);

                    try
                    {
                        koneksi = new Koneksi();
                        koneksi.buka();
                        var con = koneksi.koneksi;

                        string sql = "DELETE FROM booking WHERE id_boking = @id";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();

                        koneksi.tutup();
                        MessageBox.Show("Data berhasil dihapus.");
                        LoadData(); // Refresh dataGridView setelah hapus
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin dihapus terlebih dahulu!");
            }
        }
    }
}
