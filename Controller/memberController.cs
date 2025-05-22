using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikasi_Booking_Futsal.Model;

namespace Aplikasi_Booking_Futsal.Controller
{
    internal class memberController
    {
        memberCRUD crud = new memberCRUD();

        public DataTable GetAllMembers()
        {
            return crud.TampilkanData();
        }

        public DataTable SearchMembers(string keyword)
        {
            return crud.Cari(keyword);
        }

        public bool AddMember(Member member)
        {
            try
            {
                crud.TambahMember(member.TglDaftar, member.Team, member.Manager, member.Telp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateMember(Member member)
        {
            try
            {
                crud.UpdateMember(member.Id, member.TglDaftar, member.Team, member.Manager, member.Telp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteMember(int id)
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
