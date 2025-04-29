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
   
    public partial class main : Form
    {
        bool sidebarExpand;
        dashboard dashboard;
        booking booking;
        public main MainForm;


        public main()
        {
            InitializeComponent();
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
            menuButton.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            menuButton.Refresh(); // Refresh agar perubahan terlihat
        }

        public void showDashboard()
        {
            if (dashboard == null)
            {
                dashboard = new dashboard();
                dashboard.FormClosed += Dashboard_FormClosed;
                dashboard.MainForm = this;
                dashboard.MdiParent = this;
                dashboard.Dock = DockStyle.Fill;
                dashboard.Show();
            }
            else
            {
                dashboard.LoadData();
                dashboard.Activate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showDashboard();
        }

        private void Dashboard_FormClosed(object sender,FormClosedEventArgs e)
        {
            dashboard = null;
        }

        public void showBooking()
        {
            if (booking == null)
            {
                booking = new booking();
                booking.FormClosed += Booking_FormClosed;
                booking.MainForm = this;
                booking.MdiParent = this;
                booking.Dock = DockStyle.Fill;
                booking.Show();
            }
            else
            {
                booking.Activate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showBooking();
        }

        private void Booking_FormClosed(object sender, FormClosedEventArgs e)
        {
            booking = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void main_Load(object sender, EventArgs e)
        {
            if (dashboard == null)
            {
                dashboard = new dashboard();
                dashboard.FormClosed += Dashboard_FormClosed;
                dashboard.MainForm = this;
                dashboard.MdiParent = this;
                dashboard.Dock = DockStyle.Fill; // supaya penuh
                dashboard.Show();
            }
            else
            {
                dashboard.Activate();
            }
        }
    }
}
