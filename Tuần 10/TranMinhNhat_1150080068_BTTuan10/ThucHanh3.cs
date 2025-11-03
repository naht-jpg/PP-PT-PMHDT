using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace TranMinhNhat_1150080068_BTTuan10
{
    public partial class ThucHanh3 : Form
    {
        private readonly string _connStr =
            "User Id=app;Password=app123;Data Source=localhost:1521/XEPDB1;";

        private string _selectedKey = null;

        public ThucHanh3()
        {
            InitializeComponent();

            
            this.Load += ThucHanh3_Load;

            dtgvDanhSach.AutoGenerateColumns = true;
            dtgvDanhSach.ReadOnly = true;             
            dtgvDanhSach.MultiSelect = false;
            dtgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Click chọn dữ liệu muốn chỉnh sửa
            dtgvDanhSach.CellClick += dtgvDanhSach_CellClick;

            btnChinhSua.Click += btnChinhSua_Click;
        }

        private OracleConnection MoKetNoi()
        {
            var conn = new OracleConnection(_connStr);
            conn.Open();
            return conn;
        }

        private void ThucHanh3_Load(object sender, EventArgs e)
        {
            try
            {
                HienThiDuLieu();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu: " + ex.Message);
            }
        }

        private void HienThiDuLieu()
        {
            using (var conn = MoKetNoi())
            using (var da = new OracleDataAdapter(
                "SELECT NXB, TENNXB, DIACHI FROM NHAXUATBAN ORDER BY NXB", conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                dtgvDanhSach.DataSource = dt;

                dtgvDanhSach.Columns["NXB"].HeaderText = "Mã NXB";
                dtgvDanhSach.Columns["TENNXB"].HeaderText = "Tên NXB";
                dtgvDanhSach.Columns["DIACHI"].HeaderText = "Địa chỉ";
            }
        }

        private void ClearForm()
        {
            txtMaNXB.Text = "";
            txtTenNXB.Text = "";
            txtDiaChi.Text = "";
            _selectedKey = null;
            txtMaNXB.Focus();
        }

        private void dtgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dtgvDanhSach.Rows[e.RowIndex];
            var ma = Convert.ToString(row.Cells["NXB"].Value)?.Trim() ?? "";
            var ten = Convert.ToString(row.Cells["TENNXB"].Value) ?? "";
            var dc = Convert.ToString(row.Cells["DIACHI"].Value) ?? "";

            txtMaNXB.Text = ma;
            txtTenNXB.Text = ten;
            txtDiaChi.Text = dc;

            //phòng trường hợp người dùng đổi mã
            _selectedKey = ma;
        }

        private bool ValidateInput(out string ma, out string ten, out object diachiDb)
        {
            ma = txtMaNXB.Text.Trim();
            ten = txtTenNXB.Text.Trim();
            var dc = txtDiaChi.Text.Trim();

            if (ma.Length == 0) { MessageBox.Show("Vui lòng nhập Mã NXB."); txtMaNXB.Focus(); diachiDb = DBNull.Value; return false; }
            if (ten.Length == 0) { MessageBox.Show("Vui lòng nhập Tên NXB."); txtTenNXB.Focus(); diachiDb = DBNull.Value; return false; }

            if (ma.Length > 10) { MessageBox.Show("Mã NXB tối đa 10 ký tự."); txtMaNXB.Focus(); diachiDb = DBNull.Value; return false; }
            if (ten.Length > 100) { MessageBox.Show("Tên NXB tối đa 100 ký tự."); txtTenNXB.Focus(); diachiDb = DBNull.Value; return false; }

            diachiDb = string.IsNullOrWhiteSpace(dc) ? (object)DBNull.Value : dc;
            return true;
        }

        private bool MaNxbDaTonTai(OracleConnection conn, string ma)
        {
            using (var cmd = new OracleCommand(
                "SELECT COUNT(1) FROM NHAXUATBAN WHERE TRIM(NXB) = :NXB", conn))
            {
                cmd.Parameters.Add(":NXB", OracleDbType.Char, 10).Value = ma;
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedKey == null)
                {
                    MessageBox.Show("Bạn chưa chọn dòng để chỉnh sửa.");
                    return;
                }

                if (!ValidateInput(out var newMa, out var ten, out var diachiDb)) return;

                using (var conn = MoKetNoi())
                {
                    // Nếu người dùng đổi Mã NXB → kiểm tra trùng
                    if (!string.Equals(newMa, _selectedKey, StringComparison.Ordinal) &&
                        MaNxbDaTonTai(conn, newMa))
                    {
                        MessageBox.Show("Mã NXB mới đã tồn tại. Vui lòng chọn mã khác.");
                        return;
                    }

                    using (var cmd = new OracleCommand(@"
                        UPDATE NHAXUATBAN
                           SET NXB     = :NEW_NXB,
                               TENNXB  = :TENNXB,
                               DIACHI  = :DIACHI
                         WHERE TRIM(NXB) = :OLD_NXB", conn))
                    {
                        cmd.BindByName = true;
                        cmd.Parameters.Add(":NEW_NXB", OracleDbType.Char, 10).Value = newMa;
                        cmd.Parameters.Add(":TENNXB", OracleDbType.NVarchar2, 100).Value = ten;
                        cmd.Parameters.Add(":DIACHI", OracleDbType.NVarchar2, 500).Value = diachiDb;
                        cmd.Parameters.Add(":OLD_NXB", OracleDbType.Char, 10).Value = _selectedKey;

                        var kq = cmd.ExecuteNonQuery();
                        if (kq > 0)
                        {
                            MessageBox.Show("Chỉnh sửa dữ liệu thành công!");
                            HienThiDuLieu();
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Không có bản ghi nào được cập nhật (kiểm tra lại mã cũ).");
                        }
                    }
                }
            }
            catch (OracleException oex)
            {
                MessageBox.Show("Lỗi Oracle: " + oex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Các handler trống 
        private void label1_Click(object sender, EventArgs e) { }
        private void btnThem_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void txtMaNXB_TextChanged(object sender, EventArgs e) { }
        private void txtTenNXB_TextChanged(object sender, EventArgs e) { }
        private void txtDiaChi_TextChanged(object sender, EventArgs e) { }
        private void dtgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
