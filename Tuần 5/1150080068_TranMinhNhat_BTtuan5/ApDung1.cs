using System;
using System.Windows.Forms;

namespace _1150080068_TranMinhNhat_BTtuan5
{
    public partial class ApDung1 : Form
    {
        public ApDung1()
        {
            InitializeComponent();
        }

        private void rdoUSCLN_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoUSCLN.Checked) txtKetQua.Clear();
        }

        private void rdoBSCNN_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBSCNN.Checked) txtKetQua.Clear();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                long a = Convert.ToInt64(txtA.Text.Trim());
                long b = Convert.ToInt64(txtB.Text.Trim());

                if (!rdoUSCLN.Checked && !rdoBSCNN.Checked)
                {
                    MessageBox.Show("Vui lòng chọn USCLN hoặc BSCNN.",
                                    "Thiếu tuỳ chọn",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }

                if (rdoUSCLN.Checked)
                {
                    // Tính USCLN 
                    long x = Math.Abs(a);
                    long y = Math.Abs(b);
                    if (x == 0) { txtKetQua.Text = y.ToString(); return; }
                    if (y == 0) { txtKetQua.Text = x.ToString(); return; }
                    while (y != 0)
                    {
                        long r = x % y;
                        x = y;
                        y = r;
                    }
                    txtKetQua.Text = x.ToString();
                }
                else 
                {
                    // Tính BSCNN 
                    long x = Math.Abs(a);
                    long y = Math.Abs(b);

                    if (x == 0 || y == 0)
                    {
                        txtKetQua.Text = "0"; // quy ước: 1 số = 0 => LCM = 0
                        return;
                    }

                    // USCLN
                    long a1 = x, b1 = y;
                    while (b1 != 0)
                    {
                        long r = a1 % b1;
                        a1 = b1;
                        b1 = r;
                    }
                    long gcd = a1;

                    // chia trước, rồi nhân
                    long lcm = (x / gcd) * y;
                    txtKetQua.Text = lcm.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Thông báo lỗi!",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có thực sự thoát hay không?",
                                         "Xác nhận thoát",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.Yes) this.Close();
        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
                e.Handled = true;
        }
        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
                e.Handled = true;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { }
        private void txtA_TextChanged(object sender, EventArgs e) { }
        private void txtB_TextChanged(object sender, EventArgs e) { }
        private void txtKetQua_TextChanged(object sender, EventArgs e) { }
    }
}
