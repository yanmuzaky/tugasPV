using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplikasi_Booking_Futsal.Controller;
using Aplikasi_Booking_Futsal.Model;

namespace Aplikasi_Booking_Futsal
{
    public partial class login : Form
    {
        loginController controller = new loginController();

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama = username_txt.Text;
            string pass = pwd_txt.Text;

            User user = controller.ProsesLogin(nama, pass);

            if (user != null)
            {
                
                MessageBox.Show("Selamat datang, " + user.Nama);
                main();
            }
            else
            {
                MessageBox.Show("Login gagal!");
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
