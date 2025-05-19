using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Aplikasi_Booking_Futsal
{
    public class UserCRUD
    {
        Koneksi con = new Koneksi();

        public bool cekLogin(string nama, string password)
        {
            bool hasil = false;
            try
            {
                con.buka();
                MySqlConnection conn = con.koneksi;

                string sql = "SELECT * FROM user WHERE nama = @nama AND pass = @pass";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@pass", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    hasil = true;
                }
                reader.Close();
            }
            catch
            {
                throw;
            }
            con.tutup();
            return hasil;
        }
    }
}
