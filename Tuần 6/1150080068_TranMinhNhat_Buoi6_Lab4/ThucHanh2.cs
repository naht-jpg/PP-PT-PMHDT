using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace _1150080068_TranMinhNhat_Buoi6_Lab4
{
    public partial class ThucHanh2: Form
    {
        // Lấy chuỗi kết nối từ App.config (hoặc fallback)
        private readonly string _cs =
            ConfigurationManager.ConnectionStrings["OracleDb"]?.ConnectionString
            ?? "User Id=app;Password=app123;Data Source=localhost:1521/xepdb1;";

        // Đếm số lượng sinh viên
        private int GetStudentCount()
        {
            using (var conn = new OracleConnection(_cs))
            using (var cmd = new OracleCommand("SELECT COUNT(*) FROM SinhVien", conn))
            {
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // (Tuỳ chọn) Nạp danh sách vào DataGridView nếu bạn có dgvSinhVien
        private void LoadStudentsToGrid()
        {
            if (this.Controls.Find("dgvSinhVien", true).FirstOrDefault() is DataGridView gv)
            {
                using (var conn = new OracleConnection(_cs))
                using (var cmd = new OracleCommand(
                    "SELECT MSSV, HOTEN, TO_CHAR(NGAYSINH,'DD/MM/YYYY') NGAYSINH, LOP, DIACHI FROM SinhVien ORDER BY MSSV", conn))
                using (var da = new OracleDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    conn.Open();
                    da.Fill(dt);
                    gv.DataSource = dt;
                }
            }
        }

        // Hiển thị số lượng lên Label (ví dụ lblSLSV)
        private void ShowCount()
        {
            int n;
            try
            {
                n = GetStudentCount();
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Oracle lỗi {ex.Number}: {ex.Message}");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            // tìm label tên lblSLSV (đổi tên nếu bạn đặt khác)
            if (this.Controls.Find("lblSLSV", true).FirstOrDefault() is Label lbl)
                lbl.Text = $"Số lượng sinh viên: {n}";
            else
                MessageBox.Show($"Số lượng sinh viên: {n}");

            // (tuỳ chọn) nạp luôn danh sách vào grid
            LoadStudentsToGrid();
        }


        private void ThucHanh2_Load(object sender, EventArgs e)
        {

        }

        private void btnSLSV_Click(object sender, EventArgs e)
        {
            ShowCount();
        }
    }
}
