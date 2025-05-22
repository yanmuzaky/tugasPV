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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Aplikasi_Booking_Futsal
{
    public partial class member : Form
    {
        public main MainForm;
        memberController controller = new memberController();

        public member()
        {
            InitializeComponent();
        }

        private void member_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            search_txt.Text = "Search...  ";
            search_txt.ForeColor = Color.Gray;

            LoadData();
        }

        public void LoadData()
        {
            dataGridView1.DataSource = controller.GetAllMembers();
        }

        private Member AmbilDataForm(int? id = null)
        {
            return new Member
            {
                Id = id ?? 0,
                TglDaftar = tglDaftar_dt.Value.ToString("yyyy-MM-dd"),
                Team = teamTxt.Text,
                Manager = managerTxt.Text,
                Telp = telpTxt.Text
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Member m = AmbilDataForm();
                if (controller.AddMember(m))
                {
                    MessageBox.Show("Data berhasil ditambahkan");
                    ResetForm();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Gagal menambahkan data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Isi textbox ketika user klik baris di datagrid
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                tglDaftar_dt.Value = Convert.ToDateTime(row.Cells["tgl_daftar"].Value);
                teamTxt.Text = row.Cells["team"].Value.ToString();
                managerTxt.Text = row.Cells["manager"].Value.ToString();
                telpTxt.Text = row.Cells["telp"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_member"].Value);
                Member m = AmbilDataForm(id);

                if (controller.UpdateMember(m))
                {
                    MessageBox.Show("Data berhasil diupdate");
                    ResetForm();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Gagal mengupdate data");
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin diedit terlebih dahulu!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?",
                    "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_member"].Value);
                    if (controller.DeleteMember(id))
                    {
                        MessageBox.Show("Data berhasil dihapus.");
                        LoadData();
                        ResetForm();
                    }
                    else
                    {
                        MessageBox.Show("Gagal menghapus data.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin dihapus terlebih dahulu!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            teamTxt.Clear();
            managerTxt.Clear();
            telpTxt.Clear();
            tglDaftar_dt.Value = DateTime.Now;
        }

        

        public void CariData(string keyword)
        {
            dataGridView1.DataSource = controller.SearchMembers(keyword);
        }

        private void search_txt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(search_txt.Text) || search_txt.Text == "Search...  ")
            {
                LoadData();
            }
            else
            {
                CariData(search_txt.Text);
            }
        }

        private void search_txt_Enter(object sender, EventArgs e)
        {
            if (search_txt.Text == "Search...  ")
            {
                search_txt.Text = "";
                search_txt.ForeColor = Color.Black;
            }
        }

        private void search_txt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(search_txt.Text))
            {
                search_txt.Text = "Search...  ";
                search_txt.ForeColor = Color.Gray;
            }
        }
    }
}
