using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace _1150080068_TranMinhNhat_Buoi7_Lab5
{
    public partial class ThucHanh2 : Form
    {
        // ===== CẤU HÌNH ORACLE =====
        private const string ORACLE_CS =
            "User Id=app;Password=app123;Data Source=localhost:1521/XEPDB1;";
        private const string TABLE_NAME = "SINHVIEN2";

        private OracleConnection _conn;

        public ThucHanh2()
        {
            InitializeComponent();

            // Chuẩn hóa ListView (nếu designer chưa cấu hình)
            lstvBangSV.View = View.Details;
            lstvBangSV.FullRowSelect = true;
            lstvBangSV.GridLines = true;
            if (lstvBangSV.Columns.Count == 0)
            {
                lstvBangSV.Columns.Add("Mã SV", 90);
                lstvBangSV.Columns.Add("Tên SV", 120);
                lstvBangSV.Columns.Add("Giới tính", 80);
                lstvBangSV.Columns.Add("Ngày sinh", 100);
                lstvBangSV.Columns.Add("Quê quán", 100);
                lstvBangSV.Columns.Add("Mã lớp", 80);
            }

            // Giới tính
            cboGT.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGT.Items.Clear();
            cboGT.Items.Add("Nam");
            cboGT.Items.Add("Nữ");
            if (cboGT.Items.Count > 0) cboGT.SelectedIndex = 0;

            // Validate để bật/tắt nút Thêm
            txtMSV.TextChanged += (s, e) => ToggleAddButton();
            txtTSV.TextChanged += (s, e) => ToggleAddButton();
            ToggleAddButton();

            // Kết nối & tải dữ liệu
            try
            {
                _conn = new OracleConnection(ORACLE_CS);
                _conn.Open();
                HienThiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được kết nối Oracle.\n" + ex.Message,
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToggleAddButton()
        {
            btnThemSV.Enabled = !string.IsNullOrWhiteSpace(txtMSV.Text)
                                && !string.IsNullOrWhiteSpace(txtTSV.Text);
        }

        // ============== HIỂN THỊ DANH SÁCH (SELECT) ==============
        private void HienThiDanhSach()
        {
            if (_conn == null || _conn.State != ConnectionState.Open) return;

            string sql = string.Format(
                "SELECT MASV, TENSV, GIOITINH, NGAYSINH, QUEQUAN, MALOP FROM {0} ORDER BY MASV",
                TABLE_NAME);

            using (var cmd = new OracleCommand(sql, _conn))
            {
                lstvBangSV.Items.Clear();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        string maSv = r.GetString(0);
                        string tenSv = r.GetString(1);
                        string gt = r.GetString(2);
                        string ngaySinh = r.GetDateTime(3).ToString("dd/MM/yyyy");
                        string queQuan = r.IsDBNull(4) ? "" : r.GetString(4);
                        string maLop = r.IsDBNull(5) ? "" : r.GetString(5);

                        var item = new ListViewItem(maSv);
                        item.SubItems.Add(tenSv);
                        item.SubItems.Add(gt);
                        item.SubItems.Add(ngaySinh);
                        item.SubItems.Add(queQuan);
                        item.SubItems.Add(maLop);
                        lstvBangSV.Items.Add(item);
                    }
                }
            }
        }

        // ============== THÊM (INSERT) — KHÔNG DÙNG PARAMETER ==============
        private void btnThemSV_Click(object sender, EventArgs e)
        {
            if (_conn == null || _conn.State != ConnectionState.Open)
            {
                MessageBox.Show("Chưa kết nối Oracle.");
                return;
            }

            try
            {
                string maSV = txtMSV.Text.Trim();
                string tenSV = txtTSV.Text.Trim();
                string gioiTinh = (cboGT.SelectedItem ?? "").ToString();
                string ngayIso = dtmNS.Value.ToString("yyyy-MM-dd");
                string queQuan = txtQQ.Text.Trim();
                string maLop = txtML.Text.Trim();

                if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(tenSV))
                {
                    MessageBox.Show("Mã SV và Tên SV bắt buộc nhập.");
                    return;
                }

                string sql = string.Format(
                    "INSERT INTO {0} (MASV,TENSV,GIOITINH,NGAYSINH,QUEQUAN,MALOP) " +
                    "VALUES ('{1}', '{2}', '{3}', TO_DATE('{4}','YYYY-MM-DD'), '{5}', '{6}')",
                    TABLE_NAME, maSV, tenSV, gioiTinh, ngayIso, queQuan, maLop);

                using (var cmd = new OracleCommand(sql, _conn))
                {
                    int kq = cmd.ExecuteNonQuery();

                    using (var commit = new OracleCommand("COMMIT", _conn))
                    {
                        commit.ExecuteNonQuery();
                    }

                    if (kq > 0)
                    {
                        MessageBox.Show("Thêm sinh viên thành công!");
                        HienThiDanhSach();
                        ClearInputs();
                    }
                }
            }
            catch (OracleException ox)
            {
                if (ox.Number == 1)
                    MessageBox.Show("Mã SV đã tồn tại (trùng khóa chính).", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Lỗi Oracle: " + ox.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm dữ liệu bị lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtMSV.Clear();
            txtTSV.Clear();
            cboGT.SelectedIndex = 0;
            dtmNS.Value = DateTime.Today;
            txtQQ.Clear();
            txtML.Clear();
            txtMSV.Focus();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                if (_conn != null && _conn.State == ConnectionState.Open)
                    _conn.Close();
            }
            catch { }
            base.OnFormClosing(e);
        }

        // Handlers trống
        private void txtMSV_TextChanged(object sender, EventArgs e) { }
        private void txtTSV_TextChanged(object sender, EventArgs e) { }
        private void cboGT_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtmNS_ValueChanged(object sender, EventArgs e) { }
        private void txtQQ_TextChanged(object sender, EventArgs e) { }
        private void txtML_TextChanged(object sender, EventArgs e) { }
        private void lstvBangSV_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
