using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace TranMinhNhat_1150080068_BTTuan10
{
    public partial class ThucHanh2 : Form
    {
        private readonly string _connStr =
            "User Id=app;Password=app123;Data Source=localhost:1521/XEPDB1;";

        public ThucHanh2()
        {
            InitializeComponent();
            this.Load += ThucHanh2_Load;
            dtgvDanhSach.AutoGenerateColumns = true;
            dtgvDanhSach.ReadOnly = true;
            dtgvDanhSach.AllowUserToAddRows = false;
        }

        private OracleConnection MoKetNoi()
        {
            var conn = new OracleConnection(_connStr);
            conn.Open();
            return conn;
        }

        private void XoaDuLieuForm()
        {
            txtMaNXB.Text = "";
            txtTenNXB.Text = "";
            txtDiaChi.Text = "";
            txtMaNXB.Focus();
        }

        private void HienThiDuLieu()
        {
            using (var conn = MoKetNoi())
            using (var da = new OracleDataAdapter(
                "SELECT NXB, TENNXB, DIACHI FROM NHAXUATBAN ORDER BY NXB", conn))
            {
                var dt = new DataTable();
                da.Fill(dt);

                dt.Columns["NXB"].ColumnName = "Mã NXB";
                dt.Columns["TENNXB"].ColumnName = "Tên NXB";
                dt.Columns["DIACHI"].ColumnName = "Địa chỉ";

                dtgvDanhSach.DataSource = dt;
            }
        }

        private bool ValidateInput(out string ma, out string ten, out object diachiDb)
        {
            ma = txtMaNXB.Text.Trim();
            ten = txtTenNXB.Text.Trim();
            var diachi = txtDiaChi.Text.Trim();

            if (ma.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Mã NXB.", "Thiếu dữ liệu");
                txtMaNXB.Focus();
                diachiDb = DBNull.Value;
                return false;
            }
            if (ten.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Tên NXB.", "Thiếu dữ liệu");
                txtTenNXB.Focus();
                diachiDb = DBNull.Value;
                return false;
            }

            if (ma.Length > 10)
            {
                MessageBox.Show("Mã NXB tối đa 10 ký tự.");
                txtMaNXB.Focus();
                diachiDb = DBNull.Value;
                return false;
            }
            if (ten.Length > 100)
            {
                MessageBox.Show("Tên NXB tối đa 100 ký tự.");
                txtTenNXB.Focus();
                diachiDb = DBNull.Value;
                return false;
            }

            diachiDb = string.IsNullOrWhiteSpace(diachi) ? (object)DBNull.Value : diachi;
            return true;
        }

        private bool MaNxbDaTonTai(OracleConnection conn, string ma)
        {
            using (var cmd = new OracleCommand(
                "SELECT COUNT(1) FROM NHAXUATBAN WHERE NXB = :NXB", conn))
            {
                cmd.Parameters.Add(":NXB", OracleDbType.Char, 10).Value = ma;
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void ThucHanh2_Load(object sender, EventArgs e)
        {
            try
            {
                HienThiDuLieu();
                XoaDuLieuForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput(out var ma, out var ten, out var diachiDb)) return;

                using (var conn = MoKetNoi())
                {
                    if (MaNxbDaTonTai(conn, ma))
                    {
                        MessageBox.Show("Mã NXB đã tồn tại. Vui lòng nhập mã khác.");
                        return;
                    }

                    using (var cmd = new OracleCommand(
                        "INSERT INTO NHAXUATBAN (NXB, TENNXB, DIACHI) VALUES (:NXB, :TENNXB, :DIACHI)", conn))
                    {
                        cmd.BindByName = true; // an toàn theo tên tham số
                        cmd.Parameters.Add(":NXB", OracleDbType.Char, 10).Value = ma;
                        cmd.Parameters.Add(":TENNXB", OracleDbType.NVarchar2, 100).Value = ten;
                        cmd.Parameters.Add(":DIACHI", OracleDbType.NVarchar2, 500).Value = diachiDb;

                        var kq = cmd.ExecuteNonQuery();
                        if (kq > 0)
                        {
                            MessageBox.Show("Thêm dữ liệu thành công!");
                            HienThiDuLieu();
                            XoaDuLieuForm();
                        }
                        else
                        {
                            MessageBox.Show("Thêm dữ liệu không thành công!");
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
        private void dtgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtMaNXB_TextChanged(object sender, EventArgs e) { }
        private void txtTenNXB_TextChanged(object sender, EventArgs e) { }
        private void txtDiaChi_TextChanged(object sender, EventArgs e) { }
    }
}
