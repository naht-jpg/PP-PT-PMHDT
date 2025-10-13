using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace _1150080068_TranMinhNhat_Buoi7_Lab5
{
    public partial class ThucHanh3 : Form
    {
        private const string ORACLE_CS =
            "User Id=app;Password=app123;Data Source=localhost:1521/XEPDB1;";
        private const string TABLE_NAME = "SINHVIEN2";

        private OracleConnection _conn;

        public ThucHanh3()
        {
            InitializeComponent();

            // ListView
            lstvBangSV.View = View.Details;
            lstvBangSV.FullRowSelect = true;
            lstvBangSV.GridLines = true;
            if (lstvBangSV.Columns.Count == 0)
            {
                lstvBangSV.Columns.Add("Mã SV", 100);
                lstvBangSV.Columns.Add("Tên SV", 160);
                lstvBangSV.Columns.Add("Giới tính", 80);
                lstvBangSV.Columns.Add("Ngày sinh", 100);
                lstvBangSV.Columns.Add("Quê quán", 140);
                lstvBangSV.Columns.Add("Mã lớp", 100);
            }

            // Giới tính
            cboGT.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGT.Items.Clear();
            cboGT.Items.Add("Nam");
            cboGT.Items.Add("Nữ");
            if (cboGT.Items.Count > 0) cboGT.SelectedIndex = 0;

            // Sự kiện
            cboChonLop.SelectedIndexChanged += (s, e) => LoadDanhSachTheoLop();
            lstvBangSV.SelectedIndexChanged += lstvBangSV_SelectedIndexChanged;
            btnSuaThongTin.Click += btnSuaThongTin_Click;

            txtMSV.TextChanged += (s, e) => ToggleEditButton();
            txtTSV.TextChanged += (s, e) => ToggleEditButton();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                _conn = new OracleConnection(ORACLE_CS);
                _conn.Open();
                LoadDanhSachMaLop();
                ToggleEditButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được kết nối Oracle.\n" + ex.Message,
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToggleEditButton()
        {
            btnSuaThongTin.Enabled =
                !string.IsNullOrWhiteSpace(txtMSV.Text) &&
                !string.IsNullOrWhiteSpace(txtTSV.Text);
        }

        // ========== NẠP COMBO MÃ LỚP ==========
        private void LoadDanhSachMaLop()
        {
            if (_conn == null || _conn.State != ConnectionState.Open) return;

            string sql = "SELECT DISTINCT MALOP FROM " + TABLE_NAME + " WHERE MALOP IS NOT NULL ORDER BY MALOP";
            cboChonLop.Items.Clear();

            using (var cmd = new OracleCommand(sql, _conn))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    cboChonLop.Items.Add(r.GetString(0));
                }
            }

            if (cboChonLop.Items.Count > 0) cboChonLop.SelectedIndex = 0;
            else LoadDanhSachTheoLop(); // Không có lớp => vẫn load tất cả
        }

        // ========== HIỂN THỊ DANH SÁCH THEO LỚP ==========
        private void LoadDanhSachTheoLop()
        {
            if (_conn == null || _conn.State != ConnectionState.Open) return;

            string where = "";
            string lop = (cboChonLop.SelectedItem ?? "").ToString();
            if (!string.IsNullOrEmpty(lop))
                where = " WHERE MALOP = '" + lop.Replace("'", "''") + "'";

            string sql = "SELECT MASV, TENSV, GIOITINH, NGAYSINH, QUEQUAN, MALOP " +
                         "FROM " + TABLE_NAME + where + " ORDER BY MASV";

            lstvBangSV.Items.Clear();

            using (var cmd = new OracleCommand(sql, _conn))
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

            // Xóa vùng nhập khi đổi lớp
            ClearInputs();
        }

        // ========== CHỌN DÒNG -> ĐỔ VÀO Ô BÊN PHẢI ==========
        private void lstvBangSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvBangSV.SelectedItems.Count == 0) return;

            var it = lstvBangSV.SelectedItems[0];
            txtMSV.Text = it.SubItems[0].Text;
            txtTSV.Text = it.SubItems[1].Text;
            cboGT.SelectedItem = it.SubItems[2].Text;
            DateTime ns;
            if (DateTime.TryParse(it.SubItems[3].Text, out ns)) dtmNS.Value = ns;
            txtQQ.Text = it.SubItems[4].Text;
            txtML.Text = it.SubItems[5].Text;

            ToggleEditButton();
        }

        // ========== NÚT SỬA  ==========
        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            if (_conn == null || _conn.State != ConnectionState.Open)
            {
                MessageBox.Show("Chưa kết nối Oracle.");
                return;
            }

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

            // Ghép Chuỗi
            string sql =
                "UPDATE " + TABLE_NAME + " SET " +
                "TENSV = '" + tenSV.Replace("'", "''") + "', " +
                "GIOITINH = '" + gioiTinh.Replace("'", "''") + "', " +
                "NGAYSINH = TO_DATE('" + ngayIso + "','YYYY-MM-DD'), " +
                "QUEQUAN = '" + queQuan.Replace("'", "''") + "', " +
                "MALOP   = '" + maLop.Replace("'", "''") + "' " +
                "WHERE MASV = '" + maSV.Replace("'", "''") + "'";

            try
            {
                using (var cmd = new OracleCommand(sql, _conn))
                {
                    int kq = cmd.ExecuteNonQuery();
                    using (var commit = new OracleCommand("COMMIT", _conn))
                    {
                        commit.ExecuteNonQuery();
                    }

                    if (kq > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        LoadDanhSachTheoLop();
                        
                        SelectItemInList(maSV);
                    }
                    else
                    {
                        MessageBox.Show("Không có bản ghi nào được cập nhật.");
                    }
                }
            }
            catch (OracleException ox)
            {
                MessageBox.Show("Lỗi Oracle: " + ox.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectItemInList(string maSV)
        {
            foreach (ListViewItem it in lstvBangSV.Items)
            {
                if (it.Text.Equals(maSV, StringComparison.OrdinalIgnoreCase))
                {
                    it.Selected = true;
                    it.Focused = true;
                    it.EnsureVisible();
                    break;
                }
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
            ToggleEditButton();
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

        // Các handler trống để VS Designer giữ event
        private void txtMSV_TextChanged(object sender, EventArgs e) { }
        private void txtTSV_TextChanged(object sender, EventArgs e) { }
        private void cboGT_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtmNS_ValueChanged(object sender, EventArgs e) { }
        private void txtQQ_TextChanged(object sender, EventArgs e) { }
        private void txtML_TextChanged(object sender, EventArgs e) { }
        private void btnThemSV_Click(object sender, EventArgs e) { } 
    }
}
