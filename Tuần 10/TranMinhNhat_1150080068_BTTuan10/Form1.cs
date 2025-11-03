using System;
using System.Data;
using System.Windows.Forms;
// NuGet: Oracle.ManagedDataAccess
using Oracle.ManagedDataAccess.Client;

namespace TranMinhNhat_1150080068_BTTuan10
{
    public partial class Form1 : Form
    {
        private readonly string _connStr =
            "User Id=app;Password=app123;Data Source=localhost:1521/XEPDB1;";

        public Form1()
        {
            InitializeComponent();
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

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = MoKetNoi())
                using (var cmd = new OracleCommand(
                 
                    "SELECT NXB, TENNXB, DIACHI FROM NHAXUATBAN ORDER BY NXB",
                    conn))
                using (var da = new OracleDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    dt.Columns["NXB"].ColumnName = "Mã NXB";
                    dt.Columns["TENNXB"].ColumnName = "Tên NXB";
                    dt.Columns["DIACHI"].ColumnName = "Địa chỉ";

                    dtgvDanhSach.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message,
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
