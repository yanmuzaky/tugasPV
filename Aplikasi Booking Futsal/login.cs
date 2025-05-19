using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikasi_Booking_Futsal
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama = username_txt.Text;
            string pass = pwd_txt.Text;

            UserCRUD userCrud = new UserCRUD();

            try
            {
                bool loginBerhasil = userCrud.cekLogin(nama, pass);

                if (loginBerhasil)
                {
                    main();
                }
                else
                {
                    MessageBox.Show("Login gagal! Username atau password salah.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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
