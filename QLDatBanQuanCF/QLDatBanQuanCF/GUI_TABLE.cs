using BUS_SMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDatBanQuanCF
{
    public partial class GUI_TABLE : Form
    {
        BUS_Table busTable = new BUS_Table();
        bool tf, tf1;
        public GUI_TABLE()
        {
            InitializeComponent();
            tf = tf1 = true;
            Lock_Unlock(tf);
            Lock_Unlock1(tf1);
        }
        void Lock_Unlock(bool tf)
        {
            btnNew.Enabled = tf;
            btnThem.Enabled = txtSoBan.Enabled = txtSoChoNgoi.Enabled = txtViTri.Enabled = txtTrangThai.Enabled = !tf;
        }
        void Lock_Unlock1(bool tf1)
        {
            dgvBan.Enabled = tf1;
            btnXoa.Enabled = btnSua.Enabled = txtSoBan.Enabled = txtSoChoNgoi.Enabled = txtViTri.Enabled = txtTrangThai.Enabled = !tf1;
        }     

        private void GUI_TABLE_Load(object sender, EventArgs e)
        {
            dgvBan.DataSource = busTable.getTable();
        }

        private void lblViTri_Click(object sender, EventArgs e)
        {

        }

        private void dgvBan_Click(object sender, EventArgs e)
        {
            if (tf)
            {
                int i = dgvBan.CurrentRow.Index;
                txtSoBan.Text = dgvBan[0, i].Value.ToString();
                txtSoChoNgoi.Text = dgvBan[1, i].Value.ToString();
                txtViTri.Text = dgvBan[2, i].Value.ToString();
                txtTrangThai.Text = dgvBan[3, i].Value.ToString();
                tf1 = !tf1;
                Lock_Unlock1(tf1);
            }
            else
                MessageBox.Show("Đang thêm!\nChọn Reset để thực hiện công việc khác!", "Thông báo!");
         
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tf = tf1 = true;
            Lock_Unlock(tf);
            Lock_Unlock1(tf1);
            dgvBan.DataSource = busTable.getTable();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtSoBan.Text != "" && txtSoChoNgoi.Text != "" && txtViTri.Text != "" && txtTrangThai.Text != "")
            {
                if (busTable.suaBan(int.Parse(txtSoBan.Text), int.Parse(txtSoChoNgoi.Text), txtViTri.Text, txtTrangThai.Text))
                {
                    MessageBox.Show("Sửa thành công!", "Thông báo");
                    tf1 = !tf1;
                    Lock_Unlock1(tf1);
                    dgvBan.DataSource = busTable.getTable();
                }
                else
                    MessageBox.Show("Sửa thất bại!");
            }
            else
                MessageBox.Show("Vui lòng không để trống thông tin!", "Thông báo");
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tf1)
            {
                tf = !tf;
                Lock_Unlock(tf);
                txtSoBan.Text = txtSoChoNgoi.Text = txtViTri.Text = txtTrangThai.Text = "";
                txtSoBan.Focus();
            }
            else
                MessageBox.Show("Đang chỉnh sửa hoặc xóa!\nChọn Reset để làm việc khác!", "Thông báo");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoBan.Text != "" && txtSoChoNgoi.Text != "" && txtViTri.Text != "" && txtTrangThai.Text != "")
            {
                if (busTable.themBan(int.Parse(txtSoBan.Text), int.Parse(txtSoChoNgoi.Text), txtViTri.Text, txtTrangThai.Text))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                    tf = !tf;
                    Lock_Unlock(tf);
                    dgvBan.DataSource = busTable.getTable();
                }
                else
                    MessageBox.Show("Thêm thất bại!", "Thông báo");
            }
            else
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtSoBan.Text != null)
            {
                if (busTable.xoaBan(int.Parse(txtSoBan.Text)))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    tf1 = !tf1;
                    Lock_Unlock1(tf1);
                    dgvBan.DataSource = busTable.getTable();
                }
                else
                    MessageBox.Show("Xóa thất bại!");
            }
            else
                MessageBox.Show("Vui lòng chọn hàng muốn xóa!", "Thông báo");
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_Login x = new GUI_Login();
            x.Show();
            this.Close();
        }

        private void lịchĐặtBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_DatBan x = new GUI_DatBan();
            x.Show();
            this.Close();
        }

        private void bntTimKiem_Click(object sender, EventArgs e)
        {
            dgvBan.DataSource = busTable.getTable(txtTimKiem.Text);
        }
    }
}
