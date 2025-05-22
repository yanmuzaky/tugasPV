using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_Booking_Futsal.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Lapangan { get; set; }
        public string TglBooking { get; set; }
        public string TglMain { get; set; }
        public string JamMain { get; set; }
        public string Durasi { get; set; }
    }
}
