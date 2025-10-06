using System;
using System.Windows.Forms;

namespace _1150080068_TranMinhNhat_Buoi6_Lab3
{
    public partial class ThucHanh2 : Form
    {
        public ThucHanh2()
        {
            InitializeComponent();
            ConfigListView();
        }

        // ----------------- TIỆN ÍCH -----------------
        private void ConfigListView()
        {
            // Chế độ hiển thị dạng bảng
            lstvTTSV.View = View.Details;
            lstvTTSV.FullRowSelect = true;
            lstvTTSV.GridLines = true;
            lstvTTSV.HideSelection = false;

            if (lstvTTSV.Columns.Count == 0)
            {
                lstvTTSV.Columns.Add("Họ tên", 180);
                lstvTTSV.Columns.Add("Ngày sinh", 110);
                lstvTTSV.Columns.Add("Lớp", 120);
                lstvTTSV.Columns.Add("Địa chỉ", 220);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống.", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return !string.IsNullOrWhiteSpace(txtHoTen.Text);
        }

        private void FillInputsFromItem(ListViewItem it)
        {
            if (it == null) return;
            txtHoTen.Text = it.SubItems[0].Text;
            // parse ngày nếu cần, ở đây fill trực tiếp
            dtmNgaySinh.Value = DateTime.TryParse(it.SubItems[1].Text, out var d)
                                ? d : DateTime.Today;
            txtLop.Text = it.SubItems[2].Text;
            txtDiaChi.Text = it.SubItems[3].Text;
        }

        private void ClearInputs()
        {
            txtHoTen.Clear();
            txtLop.Clear();
            txtDiaChi.Clear();
            dtmNgaySinh.Value = DateTime.Today;
            txtHoTen.Focus();
        }

        // ----------------- SỰ KIỆN -----------------
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var item = new ListViewItem(txtHoTen.Text.Trim());
            item.SubItems.Add(dtmNgaySinh.Value.ToString("dd/MM/yyyy"));
            item.SubItems.Add(txtLop.Text.Trim());
            item.SubItems.Add(txtDiaChi.Text.Trim());

            lstvTTSV.Items.Add(item);
            ClearInputs();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lstvTTSV.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn 1 dòng để sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateInput()) return;

            var it = lstvTTSV.SelectedItems[0];
            it.SubItems[0].Text = txtHoTen.Text.Trim();
            it.SubItems[1].Text = dtmNgaySinh.Value.ToString("dd/MM/yyyy");
            it.SubItems[2].Text = txtLop.Text.Trim();
            it.SubItems[3].Text = txtDiaChi.Text.Trim();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstvTTSV.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xoá.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Xoá dòng đã chọn?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lstvTTSV.Items.Remove(lstvTTSV.SelectedItems[0]);
                ClearInputs();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstvTTSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvTTSV.SelectedItems.Count == 0) return;
            FillInputsFromItem(lstvTTSV.SelectedItems[0]);
        }

        // Các handler TextChanged/ValueChanged nếu không dùng có thể để trống
        private void txtHoTen_TextChanged(object sender, EventArgs e) { }
        private void txtLop_TextChanged(object sender, EventArgs e) { }
        private void dtmNgaySinh_ValueChanged(object sender, EventArgs e) { }
        private void txtDiaChi_TextChanged(object sender, EventArgs e) { }
    }
}
