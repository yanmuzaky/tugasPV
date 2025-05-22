using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikasi_Booking_Futsal.Model;
using System.Windows.Forms;

namespace Aplikasi_Booking_Futsal.Controller
{
    internal class loginController
    {
        UserCRUD userCrud = new UserCRUD();
        public User ProsesLogin(string username, string password)
        {
            try
            {
                return userCrud.cekLogin(username, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                return null;
            }
        }
    }

    
    }
