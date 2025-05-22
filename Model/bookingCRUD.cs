using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Aplikasi_Booking_Futsal
{
    internal class bookingCRUD
    {
        private Koneksi koneksi = new Koneksi();

        public DataTable TampilkanData()
        {
            koneksi.buka();
            string sql = "SELECT * FROM booking";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, koneksi.koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            koneksi.tutup();
            return ds.Tables[0];
        }

        public DataTable Cari(string keyword)
        {
            koneksi.buka();
            string sql = "SELECT * FROM booking WHERE nama LIKE @keyword OR tgl_booking LIKE @keyword";
            MySqlCommand cmd = new MySqlCommand(sql, koneksi.koneksi);
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            koneksi.tutup();
            return ds.Tables[0];
        }

        public void TambahBooking(string nama, string lapangan, string tglBooking, string tglMain, string jamMain, string durasi)
        {
            try
            {
                koneksi.buka();
                string query = "INSERT INTO booking (nama, lapangan, tgl_booking, tgl_main, jam_main, durasi) " +
                               "VALUES (@nama, @lapangan, @tgl_booking, @tgl_main, @jam_main, @durasi)";
                MySqlCommand cmd = new MySqlCommand(query, koneksi.koneksi);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@lapangan", lapangan);
                cmd.Parameters.AddWithValue("@tgl_booking", tglBooking);
                cmd.Parameters.AddWithValue("@tgl_main", tglMain);
                cmd.Parameters.AddWithValue("@jam_main", jamMain);
                cmd.Parameters.AddWithValue("@durasi", durasi);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                koneksi.tutup();
            }
        }

        public void UpdateBooking(int id, string nama, string lapangan, string tglBooking, string tglMain, string jamMain, string durasi)
        {
            try
            {
                koneksi.buka();
                string query = "UPDATE booking SET nama = @nama, lapangan = @lapangan, tgl_booking = @tgl_booking, " +
                               "tgl_main = @tgl_main, jam_main = @jam_main, durasi = @durasi WHERE id_boking = @id";
                MySqlCommand cmd = new MySqlCommand(query, koneksi.koneksi);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@lapangan", lapangan);
                cmd.Parameters.AddWithValue("@tgl_booking", tglBooking);
                cmd.Parameters.AddWithValue("@tgl_main", tglMain);
                cmd.Parameters.AddWithValue("@jam_main", jamMain);
                cmd.Parameters.AddWithValue("@durasi", durasi);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                koneksi.tutup();
            }
        }

        public void Hapus(int id)
        {
            koneksi.buka();
            string sql = "DELETE FROM booking WHERE id_boking = @id";
            MySqlCommand cmd = new MySqlCommand(sql, koneksi.koneksi);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            koneksi.tutup();
        }
    }
}
