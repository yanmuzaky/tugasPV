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
    public partial class login : Form
    {
        private Koneksi koneksi;

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            koneksi = new Koneksi();
            try
            {
                koneksi.buka();
                var con = koneksi.koneksi;

                string stm = "select nama,pass from user WHERE nama='" + username_txt.Text + "' " +
                    "AND pass ='" + pwd_txt.Text + "';";
                var cmd = new MySqlCommand(stm, con);
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    main();
                }
                else
                {
                    MessageBox.Show("Login gagal: username atau password salah");
                }

                reader.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            koneksi.tutup();
            
        }

        public void main() 
        {
            main main = new main();
            main.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
