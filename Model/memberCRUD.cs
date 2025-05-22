using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Aplikasi_Booking_Futsal
{
    internal class memberCRUD
    {
        private Koneksi koneksi = new Koneksi();

        public DataTable TampilkanData()
        {
            koneksi.buka();
            string sql = "SELECT * FROM members";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, koneksi.koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            koneksi.tutup();
            return ds.Tables[0];
        }

        public DataTable Cari(string keyword)
        {
            koneksi.buka();
            string sql = "SELECT * FROM members WHERE manager LIKE @keyword OR team LIKE @keyword";
            MySqlCommand cmd = new MySqlCommand(sql, koneksi.koneksi);
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            koneksi.tutup();
            return ds.Tables[0];
        }

        public void TambahMember(string tglDaftar,string team, string manager, string telp)
        {
            try
            {
                koneksi.buka();
                string query = "INSERT INTO members (tgl_daftar, team, manager, telp) " +
                               "VALUES (@tgl_daftar, @team, @manager, @telp)";
                MySqlCommand cmd = new MySqlCommand(query, koneksi.koneksi);
                cmd.Parameters.AddWithValue("@tgl_daftar", tglDaftar);
                cmd.Parameters.AddWithValue("@team", team);
                cmd.Parameters.AddWithValue("@manager", manager);
                cmd.Parameters.AddWithValue("@telp", telp);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                koneksi.tutup();
            }
        }

        public void UpdateMember(int id , string tglDaftar, string team, string manager, string telp)
        {
            try
            {
                koneksi.buka();
                string query = "UPDATE members SET tgl_daftar = @tgl_daftar, team = @team, manager = @manager, telp = @telp WHERE id_member = @id";
                MySqlCommand cmd = new MySqlCommand(query, koneksi.koneksi);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@tgl_daftar", tglDaftar);
                cmd.Parameters.AddWithValue("@team", team);
                cmd.Parameters.AddWithValue("@manager", manager);
                cmd.Parameters.AddWithValue("@telp", telp);
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
            string sql = "DELETE FROM members WHERE id_member = @id";
            MySqlCommand cmd = new MySqlCommand(sql, koneksi.koneksi);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            koneksi.tutup();
        }
    }
}
