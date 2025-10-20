using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _1150080068_TranMinhNhat_Buoi8_Lab6
{
    public partial class ThucHanh2 : Form
    {
        private readonly string _connStr =
            "User Id=APP;Password=app123;Data Source=127.0.0.1:1521/XEPDB1;";

        private OracleConnection _conn;

        public ThucHanh2()
        {
            InitializeComponent();

            if (lstvDanhSachNXB.Columns.Count == 0)
            {
                lstvDanhSachNXB.View = View.Details;
                lstvDanhSachNXB.FullRowSelect = true;
                lstvDanhSachNXB.Columns.Add("Mã NXB", 100);
                lstvDanhSachNXB.Columns.Add("Tên NXB", 220);
                lstvDanhSachNXB.Columns.Add("Địa chỉ", 280);
            }

            // Sự kiện
            this.Load += ThucHanh2_Load;
            btnThemNXB.Click += btnThemNXB_Click;
            lstvDanhSachNXB.SelectedIndexChanged += lstvDanhSachNXB_SelectedIndexChanged;
        }

        private void OpenConn()
        {
            if (_conn == null) _conn = new OracleConnection(_connStr);
            if (_conn.State == ConnectionState.Closed) _conn.Open();
        }

        private void CloseConn()
        {
            if (_conn != null && _conn.State == ConnectionState.Open) _conn.Close();
        }

        // ====== Load danh sách NXB ======
        private void LoadDanhSachNXB()
        {
            try
            {
                OpenConn();
                string sql = @"SELECT NXB, TenNXB, DiaChi
                               FROM NhaXuatBan
                               ORDER BY NXB";

                using (var cmd = new OracleCommand(sql, _conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (var reader = cmd.ExecuteReader())
                    {
                        lstvDanhSachNXB.BeginUpdate();
                        lstvDanhSachNXB.Items.Clear();

                        while (reader.Read())
                        {
                            string ma = reader.GetString(0).Trim();               // CHAR(10) -> Trim
                            string ten = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            string dia = reader.IsDBNull(2) ? "" : reader.GetString(2);

                            var item = new ListViewItem(ma);
                            item.SubItems.Add(ten);
                            item.SubItems.Add(dia);
                            lstvDanhSachNXB.Items.Add(item);
                        }
                        lstvDanhSachNXB.EndUpdate();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message);
            }
            finally
            {
                CloseConn();
            }
        }

        // ====== Thêm NXB ======
        private void InsertNXB(string maNXB, string tenNXB, string diaChi)
        {
            // validate cơ bản
            if (string.IsNullOrWhiteSpace(maNXB))
                throw new Exception("Mã NXB không được trống.");
            if (maNXB.Length > 10)
                throw new Exception("Mã NXB tối đa 10 ký tự.");
            if (tenNXB?.Length > 100)
                throw new Exception("Tên NXB tối đa 100 ký tự.");
            if (diaChi?.Length > 500)
                throw new Exception("Địa chỉ tối đa 500 ký tự.");

            try
            {
                OpenConn();

                // kiểm tra trùng khóa
                using (var check = new OracleCommand(
                    "SELECT COUNT(*) FROM NhaXuatBan WHERE TRIM(NXB) = :p_ma", _conn))
                {
                    check.BindByName = true;
                    check.Parameters.Add(":p_ma", OracleDbType.Varchar2, maNXB, ParameterDirection.Input);
                    var cnt = Convert.ToInt32(check.ExecuteScalar());
                    if (cnt > 0) throw new Exception("Mã NXB đã tồn tại.");
                }

                // chèn bản ghi
                using (var cmd = new OracleCommand(
                    "INSERT INTO NhaXuatBan (NXB, TenNXB, DiaChi) VALUES (:p_ma, :p_ten, :p_dc)", _conn))
                {
                    cmd.BindByName = true;

                    cmd.Parameters.Add(":p_ma", OracleDbType.Char, 10).Value = maNXB.PadRight(10);
                    cmd.Parameters.Add(":p_ten", OracleDbType.NVarchar2, 100).Value =
                        (object)(tenNXB ?? string.Empty);
                    cmd.Parameters.Add(":p_dc", OracleDbType.NVarchar2, 500).Value =
                        (object)(diaChi ?? string.Empty);

                    var rows = cmd.ExecuteNonQuery();
                    if (rows <= 0) throw new Exception("Không thêm được bản ghi.");
                }
            }
            catch (OracleException ex) when (ex.Number == 1)
            {
                throw new Exception("Mã NXB đã tồn tại (ORA-00001).");
            }
            finally
            {
                CloseConn();
            }
        }

        // ====== Sự kiện ======
        private void ThucHanh2_Load(object sender, EventArgs e)
        {
            LoadDanhSachNXB();
            txtMaNXB.Focus();
        }

        private void btnThemNXB_Click(object sender, EventArgs e)
        {
            try
            {
                var ma = (txtMaNXB.Text ?? "").Trim();
                var ten = (txtTenNXB.Text ?? "").Trim();
                var dc = (txtDiaChi.Text ?? "").Trim();

                InsertNXB(ma, ten, dc);
                MessageBox.Show("Thêm nhà xuất bản thành công!");

                txtMaNXB.Text = txtTenNXB.Text = txtDiaChi.Text = "";
                LoadDanhSachNXB();
                txtMaNXB.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm NXB: " + ex.Message);
            }
        }

        private void lstvDanhSachNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvDanhSachNXB.SelectedItems.Count == 0) return;
            var it = lstvDanhSachNXB.SelectedItems[0];
            txtMaNXB.Text = it.SubItems[0].Text;
            txtTenNXB.Text = it.SubItems[1].Text;
            txtDiaChi.Text = it.SubItems[2].Text;
        }
        private void txtMaNXB_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenNXB_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
