using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _1150080068_TranMinhNhat_BTtuan5
{
    public partial class ThucHanh2 : Form
    {
        public ThucHanh2()
        {
            InitializeComponent();

      
            nudHanRang.Enabled = false;
            nudBeRang.Enabled = false;
            nudBocRang.Enabled = false;

            nudHanRang.Minimum = 0; nudBeRang.Minimum = 0; nudBocRang.Minimum = 0;
            nudHanRang.Maximum = 100; nudBeRang.Maximum = 100; nudBocRang.Maximum = 100;

            txtKetQua.ReadOnly = true;
        }

        // ===== CheckBox bật/tắt số lượng =====
        private void chkHanRang_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHanRang.Checked)
            {
                nudHanRang.Enabled = true;
                if (nudHanRang.Value == 0) nudHanRang.Value = 1;
            }
            else
            {
                nudHanRang.Enabled = false;
                nudHanRang.Value = 0;
            }
        }

        private void chkBeRang_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBeRang.Checked)
            {
                nudBeRang.Enabled = true;
                if (nudBeRang.Value == 0) nudBeRang.Value = 1;
            }
            else
            {
                nudBeRang.Enabled = false;
                nudBeRang.Value = 0;
            }
        }

        private void chkBocRang_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBocRang.Checked)
            {
                nudBocRang.Enabled = true;
                if (nudBocRang.Value == 0) nudBocRang.Value = 1;
            }
            else
            {
                nudBocRang.Enabled = false;
                nudBocRang.Value = 0;
            }
        }
        private void chkLayCaoR_CheckedChanged(object sender, EventArgs e) { }
        private void chkTayTrangR_CheckedChanged(object sender, EventArgs e) { }

        // ===== Tính tiền =====
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            try
            {
                // Không để trống tên khách hàng
                if (string.IsNullOrWhiteSpace(txtTenKH.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thiếu thông tin",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenKH.Focus();
                    return;
                }

                decimal tong = 0m;

               
                if (chkLayCaoR.Checked)
                    tong += 50000m;

                
                if (chkTayTrangR.Checked)
                    tong += 100000m;

                
                if (chkHanRang.Checked && nudHanRang.Enabled)
                    tong += 100000m * nudHanRang.Value;

                if (chkBeRang.Checked && nudBeRang.Enabled)
                    tong += 10000m * nudBeRang.Value;

                if (chkBocRang.Checked && nudBocRang.Enabled)
                    tong += 1000000m * nudBocRang.Value;

                // Hiển thị dạng tiền Việt 
                txtKetQua.Text = string.Format(CultureInfo.GetCultureInfo("vi-VN"), "{0:N0} đ", tong);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        // ===== Thoát =====
        private void btnThoat_Click(object sender, EventArgs e)
        {
            var kq = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes) this.Close();
        }


        private void label3_Click(object sender, EventArgs e) { }
        private void txtTenKH_TextChanged(object sender, EventArgs e) { }
        private void nudHanRang_ValueChanged(object sender, EventArgs e) { }
        private void nudBeRang_ValueChanged(object sender, EventArgs e) { }
        private void nudBocRang_ValueChanged(object sender, EventArgs e) { }
        private void txtKetQua_TextChanged(object sender, EventArgs e) { }
    }
}