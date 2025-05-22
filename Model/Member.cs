using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_Booking_Futsal.Model
{
    public class Member
    {
        public int Id { get; set; }
        public string TglDaftar { get; set; }
        public string Team { get; set; }
        public string Manager { get; set; }
        public string Telp { get; set; }
    }
}
