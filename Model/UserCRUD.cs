using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikasi_Booking_Futsal.Model;
using MySql.Data.MySqlClient;

namespace Aplikasi_Booking_Futsal
{
    public class UserCRUD
    {
        Koneksi con = new Koneksi();

        public User cekLogin(string nama, string password)
        {
            User user = null;
            try
            {
                con.buka();
                MySqlConnection conn = con.koneksi;

                string sql = "SELECT * FROM user WHERE nama = @nama AND pass = @pass";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@pass", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User
                    {
                        Id = Convert.ToInt32(reader["id_user"]),
                        Nama = reader["nama"].ToString(),
                        Pass = reader["pass"].ToString()
                    };
                }
                reader.Close();
            }
            catch
            {
                throw;
            }
            con.tutup();
            return user;
        }
    }
}
