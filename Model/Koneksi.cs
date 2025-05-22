using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Aplikasi_Booking_Futsal
{
    internal class Koneksi
    {
        string mysqlCon = "server=127.0.0.1;user=root;database=nsyfutsal;password=";
        public MySqlConnection koneksi;

        public void buka()
        {
            koneksi = new MySqlConnection(mysqlCon);
            koneksi.Open();
        }

        public void tutup()
        {
            koneksi = new MySqlConnection(mysqlCon);
            koneksi.Close();
        }
    }
}
