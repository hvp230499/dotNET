using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_SMS;

namespace QLDatBanQuanCF
{
    public partial class GUI_DatBan : Form
    {
        BUS_DatBan busDatBan = new BUS_DatBan();
        bool tf, tf1;
        int maDatBan = -1;
        public GUI_DatBan()
        {
            InitializeComponent();
            tf = tf1 = true;
            Lock_Unlock(tf);
            Lock_Unlock1(tf1);
        }
        void Lock_Unlock(bool tf)
        {
            btnNew.Enabled = tf;
            btnThem.Enabled = txtSoBan.Enabled = txtBatDau.Enabled = txtKetThuc.Enabled = txtSDT.Enabled = !tf;
        }
        void Lock_Unlock1(bool tf1)
        {
            dgvDatBan.Enabled = tf1;
            btnXoa.Enabled = btnSua.Enabled = txtSoBan.Enabled = txtBatDau.Enabled = txtKetThuc.Enabled = txtSDT.Enabled = !tf1;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tf1)
            {
                tf = !tf;
                Lock_Unlock(tf);
                txtSoBan.Text = txtBatDau.Text = txtKetThuc.Text = txtSDT.Text = "";
                txtSoBan.Focus();
            }
            else
                MessageBox.Show("Đang chỉnh sửa hoặc xóa!\nChọn Reset để làm việc khác!", "Thông báo");
        }

        private void bntTimKiem_Click(object sender, EventArgs e)
        {
            dgvDatBan.DataSource = busDatBan.getDatBan(txtTimKiem.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoBan.Text != "" && txtBatDau.Text != "" && txtKetThuc.Text != "" && txtSDT.Text != "")
            {
                if (busDatBan.themLich(int.Parse(txtSoBan.Text), txtBatDau.Text, txtKetThuc.Text, txtSDT.Text))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                    tf = !tf;
                    Lock_Unlock(tf);
                    dgvDatBan.DataSource = busDatBan.getDatBan();
                }
                else
                    MessageBox.Show("Thêm thất bại!");
            }
            else
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtSoBan.Text != "" && txtBatDau.Text != "" && txtKetThuc.Text != "" && txtSDT.Text != "")
            {
                if (busDatBan.suaLich(maDatBan, int.Parse(txtSoBan.Text), txtBatDau.Text, txtKetThuc.Text, txtSDT.Text))
                {
                    MessageBox.Show("Sửa thành công!", "Thông báo");
                    tf1 = !tf1;
                    Lock_Unlock1(tf1);
                    dgvDatBan.DataSource = busDatBan.getDatBan();
                }
                else
                    MessageBox.Show("Sửa thất bại!");
            }
            else
                MessageBox.Show("Vui lòng không để trống thông tin!", "Thông báo");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maDatBan != -1)
            {
                if (busDatBan.xoaLich(maDatBan))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    tf1 = !tf1;
                    Lock_Unlock1(tf1);
                    dgvDatBan.DataSource = busDatBan.getDatBan();
                }
                else
                    MessageBox.Show("Xóa thất bại!");
            }
            else
                MessageBox.Show("Vui lòng chọn hàng muốn xóa!", "Thông báo");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tf = tf1 = true;
            Lock_Unlock(tf);
            Lock_Unlock1(tf1);
            dgvDatBan.DataSource = busDatBan.getDatBan();
        }

        private void GUI_DatBan_Load(object sender, EventArgs e)
        {
            dgvDatBan.DataSource = busDatBan.getDatBan();
        }

        private void dgvDatBan_Click(object sender, EventArgs e)
        {
            if (tf)
            {
                int i = dgvDatBan.CurrentRow.Index;                           
                maDatBan = int.Parse(dgvDatBan[0, i].Value.ToString());
                txtSoBan.Text = dgvDatBan[1, i].Value.ToString();
                txtBatDau.Text = dgvDatBan[2, i].Value.ToString();
                txtKetThuc.Text = dgvDatBan[3, i].Value.ToString();
                txtSDT.Text = dgvDatBan[4, i].Value.ToString();
                tf1 = !tf1;
                Lock_Unlock1(tf1);
            }
            else
                MessageBox.Show("Đang thêm!\nChọn Reset để thực hiện công việc khác!", "Thông báo!");
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
            GUI_TABLE x = new GUI_TABLE();
            x.Show();
            this.Close();
        }
    }
}
