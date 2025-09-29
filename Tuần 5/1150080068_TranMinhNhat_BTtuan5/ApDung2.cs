using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1150080068_TranMinhNhat_BTtuan5
{
    public partial class ApDung2 : Form
    {
        public ApDung2()
        {
            InitializeComponent();
            if (lstvLoginLog.Columns.Count == 0)
            {
                lstvLoginLog.View = View.Details;
                lstvLoginLog.FullRowSelect = true;
                lstvLoginLog.GridLines = true;
                lstvLoginLog.Columns.Add("Ngày giờ", 140);
                lstvLoginLog.Columns.Add("Nhóm", 160);
                lstvLoginLog.Columns.Add("Kết quả", 120);
            }
        }

        // ---- Bàn phím số (tối đa 4 ký tự) ----
        private void btn1_Click(object sender, EventArgs e) { if (txtPassword.TextLength < 4) txtPassword.Text += "1"; }
        private void btn2_Click(object sender, EventArgs e) { if (txtPassword.TextLength < 4) txtPassword.Text += "2"; }
        private void btn3_Click(object sender, EventArgs e) { if (txtPassword.TextLength < 4) txtPassword.Text += "3"; }
        private void btn4_Click(object sender, EventArgs e) { if (txtPassword.TextLength < 4) txtPassword.Text += "4"; }
        private void btn5_Click(object sender, EventArgs e) { if (txtPassword.TextLength < 4) txtPassword.Text += "5"; }
        private void btn6_Click(object sender, EventArgs e) { if (txtPassword.TextLength < 4) txtPassword.Text += "6"; }
        private void btn7_Click(object sender, EventArgs e) { if (txtPassword.TextLength < 4) txtPassword.Text += "7"; }
        private void btn8_Click(object sender, EventArgs e) { if (txtPassword.TextLength < 4) txtPassword.Text += "8"; }
        private void btn9_Click(object sender, EventArgs e) { if (txtPassword.TextLength < 4) txtPassword.Text += "9"; }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtPassword.Focus();
        }

        // ---- ENTER: kiểm tra mật khẩu và ghi log ----
        private void btnEnter_Click(object sender, EventArgs e)
        {
            string pw = txtPassword.Text.Trim();
            string nhom = "Không có";
            string ketQua = "Từ chối!";

            try
            {
                if (pw.Length != 4)
                {
                    MessageBox.Show("Password phải gồm 4 chữ số.", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                    return;
                }

                // Password đúng cho các nhóm thành viên
                // Phát triển công nghệ: 1496 hoặc 2673
                // Nghiên cứu viên: 7462
                // Thiết kế mô hình: 8884 hoặc 3842 hoặc 3383
                if (pw == "1496" || pw == "2673")
                {
                    nhom = "Phát triển công nghệ";
                    ketQua = "Chấp nhận!";
                }
                else if (pw == "7462")
                {
                    nhom = "Nghiên cứu viên";
                    ketQua = "Chấp nhận!";
                }
                else if (pw == "8884" || pw == "3842" || pw == "3383")
                {
                    nhom = "Thiết kế mô hình!";
                    ketQua = "Chấp nhận!";
                }

                // Ghi log vào ListView
                var item = new ListViewItem(DateTime.Now.ToString("g"));
                item.SubItems.Add(nhom);
                item.SubItems.Add(ketQua);
                lstvLoginLog.Items.Add(item);

                // Thông báo nhẹ & dọn ô nhập
                if (ketQua.StartsWith("Chấp"))
                    SystemSounds.Asterisk.Play();
                else
                    SystemSounds.Hand.Play();

                txtPassword.Clear();
                txtPassword.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---- RING: chuông cảnh báo ----
        private void btnRING_Click(object sender, EventArgs e)
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("Chuông báo động đang rung!", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void lstvLoginLog_SelectedIndexChanged(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { } 
    }
}
