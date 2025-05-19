using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Aplikasi_Booking_Futsal
{
    public partial class member : Form
    {
        public main MainForm;
        memberCRUD memberCrud = new memberCRUD();

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
            dataGridView1.DataSource = memberCrud.TampilkanData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string tanggalDaftar = tglDaftar_dt.Value.ToString("yyyy-MM-dd");
                string team = teamTxt.Text;
                string manager = managerTxt.Text;
                string telp = telpTxt.Text;

                memberCrud.TambahMember(tanggalDaftar, team, manager, telp);
                MessageBox.Show("Data Berhasil Ditambahkan");
                
                ResetForm();
                LoadData();
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
                try
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_member"].Value);
                    string tanggalDaftar = tglDaftar_dt.Value.ToString("yyyy-MM-dd");
                    string team = teamTxt.Text;
                    string manager = managerTxt.Text;
                    string telp = telpTxt.Text;

                    memberCrud.UpdateMember(id,tanggalDaftar, team, manager, telp);
                    MessageBox.Show("Data Berhasil Diupdate");

                    ResetForm();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin edit terlebih dahulu!");
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

                    try
                    {
                        memberCrud.Hapus(id);
                        MessageBox.Show("Data berhasil dihapus.");
                        LoadData();
                        ResetForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan: " + ex.Message);
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
            dataGridView1.DataSource = memberCrud.Cari(keyword);
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
