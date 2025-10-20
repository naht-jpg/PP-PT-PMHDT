using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _1150080068_TranMinhNhat_Buoi8_Lab6
{
    public partial class Form1 : Form
    {
        private readonly string _connStr =
            "User Id=APP;Password=app123;Data Source=127.0.0.1:1521/XEPDB1;";

        private OracleConnection _conn;

        public Form1()
        {
            InitializeComponent();
            if (lstvDanhSach.Columns.Count == 0)
            {
                lstvDanhSach.View = View.Details;
                lstvDanhSach.FullRowSelect = true;
                lstvDanhSach.Columns.Add("Mã NXB", 100);
                lstvDanhSach.Columns.Add("Tên NXB", 220);
                lstvDanhSach.Columns.Add("Địa chỉ", 280);
            }

            lstvDanhSach.SelectedIndexChanged += lstvDanhSach_SelectedIndexChanged;
            this.Load += Form1_Load;
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

        // =====  Hiển thị danh sách NXB  =====
        private void HienThiDanhSachNXB()
        {
            try
            {
                OpenConn();
                string sql = @"SELECT NXB, TenNXB, DiaChi
                       FROM NhaXuatBan
                       ORDER BY NXB";

                using (var cmd = new Oracle.ManagedDataAccess.Client.OracleCommand(sql, _conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (var reader = cmd.ExecuteReader())
                    {
                        lstvDanhSach.BeginUpdate();
                        lstvDanhSach.Items.Clear();

                        while (reader.Read())
                        {
                            string ma = reader.GetString(0).Trim();               // CHAR(10) -> Trim
                            string ten = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            string diachi = reader.IsDBNull(2) ? "" : reader.GetString(2);

                            var item = new ListViewItem(ma);
                            item.SubItems.Add(ten);
                            item.SubItems.Add(diachi);
                            lstvDanhSach.Items.Add(item);
                        }
                        lstvDanhSach.EndUpdate();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị NXB: " + ex.Message);
            }
            finally
            {
                CloseConn();
            }
        }

        // ===== Chi tiết NXB theo mã =====
        private void HienThiThongTinNXBTheoMa(string maNXB)
        {
            if (string.IsNullOrWhiteSpace(maNXB)) return;

            try
            {
                OpenConn();
                string sql = @"SELECT NXB, TenNXB, DiaChi
                       FROM NhaXuatBan
                       WHERE NXB = :p_ma"; // dùng tham số bind

                using (var cmd = new Oracle.ManagedDataAccess.Client.OracleCommand(sql, _conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.BindByName = true;
                    // NXB là CHAR(10) -> pad/phủ để khớp nếu dữ liệu lưu dạng fixed-length
                    cmd.Parameters.Add(":p_ma", Oracle.ManagedDataAccess.Client.OracleDbType.Char, 10)
                                  .Value = maNXB;

                    using (var reader = cmd.ExecuteReader())
                    {
                        var tbMa = Controls.Find("txtMaNXB", true).FirstOrDefault() as TextBox;
                        var tbTen = Controls.Find("txtTenNXB", true).FirstOrDefault() as TextBox;
                        var tbDia = Controls.Find("txtDiaChi", true).FirstOrDefault() as TextBox;

                        if (tbMa != null) tbMa.Text = "";
                        if (tbTen != null) tbTen.Text = "";
                        if (tbDia != null) tbDia.Text = "";

                        if (reader.Read())
                        {
                            string ma = reader.GetString(0).Trim();
                            string ten = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            string dia = reader.IsDBNull(2) ? "" : reader.GetString(2);

                            if (tbMa != null) tbMa.Text = ma;
                            if (tbTen != null) tbTen.Text = ten;
                            if (tbDia != null) tbDia.Text = dia;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị chi tiết NXB: " + ex.Message);
            }
            finally
            {
                CloseConn();
            }
        }


        // ===== Sự kiện =====
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNXB();
        }

        private void lstvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvDanhSach.SelectedItems.Count == 0) return;
            string ma = lstvDanhSach.SelectedItems[0].SubItems[0].Text;
            HienThiThongTinNXBTheoMa(ma);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
