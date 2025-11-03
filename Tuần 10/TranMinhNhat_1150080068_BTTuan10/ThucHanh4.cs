using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace TranMinhNhat_1150080068_BTTuan10
{
    public partial class ThucHanh4 : Form
    {
        private readonly string _connStr =
            "User Id=app;Password=app123;Data Source=localhost:1521/XEPDB1;";

        private string _selectedKey = null; 

        public ThucHanh4()
        {
            InitializeComponent();

            this.Load += ThucHanh4_Load;

            dtgvDanhSach.AutoGenerateColumns = true;
            dtgvDanhSach.ReadOnly = true;
            dtgvDanhSach.MultiSelect = false;
            dtgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // chọn dòng & nút xóa
            dtgvDanhSach.CellClick += dtgvDanhSach_CellClick;
            btnXoa.Click += btnXoa_Click;

            dtgvDanhSach.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Delete) btnXoa.PerformClick();
            };
        }

        private OracleConnection MoKetNoi()
        {
            var conn = new OracleConnection(_connStr);
            conn.Open();
            return conn;
        }

        private void ThucHanh4_Load(object sender, EventArgs e)
        {
            try { HienThiDuLieu(); }
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

            _selectedKey = null;
        }

        private void dtgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dtgvDanhSach.Rows[e.RowIndex];
            _selectedKey = Convert.ToString(row.Cells["NXB"].Value)?.Trim();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_selectedKey))
                {
                    MessageBox.Show("Bạn chưa chọn dữ liệu để xóa!");
                    return;
                }

                var ask = MessageBox.Show(
                    $"Bạn có chắc muốn xóa NXB '{_selectedKey}' không?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (ask != DialogResult.Yes) return;

                using (var conn = MoKetNoi())
                using (var cmd = new OracleCommand(
                    "DELETE FROM NHAXUATBAN WHERE TRIM(NXB) = :NXB", conn))
                {
                    cmd.BindByName = true;
                    cmd.Parameters.Add(":NXB", OracleDbType.Char, 10).Value = _selectedKey;

                    var kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công!");
                        HienThiDuLieu();
                    }
                    else
                    {
                        MessageBox.Show("Không có bản ghi nào bị xóa. Kiểm tra lại mã NXB.");
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

        // handler trống 
        private void dtgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
