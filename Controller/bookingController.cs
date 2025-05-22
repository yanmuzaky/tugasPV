using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikasi_Booking_Futsal.Model;

namespace Aplikasi_Booking_Futsal.Controller
{
    internal class bookingController
    {
        bookingCRUD crud = new bookingCRUD();

        public DataTable GetAllBookings()
        {
            return crud.TampilkanData();
        }

        public DataTable SearchBooking(string keyword)
        {
            return crud.Cari(keyword);
        }

        public bool AddBooking(Booking booking)
        {
            try
            {
                crud.TambahBooking(booking.Nama, booking.Lapangan, booking.TglBooking, booking.TglMain, booking.JamMain, booking.Durasi);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateBooking(Booking booking)
        {
            try
            {
                crud.UpdateBooking(booking.Id, booking.Nama, booking.Lapangan, booking.TglBooking, booking.TglMain, booking.JamMain, booking.Durasi);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBooking(int id)
        {
            try
            {
                crud.Hapus(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
