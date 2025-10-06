using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _1150080068_TranMinhNhat_Buoi6_Lab3
{
    public partial class ThucHanh1 : Form
    {
        // Lưu đơn theo từng bàn:  Bàn -> {Món -> Số lượng}
        private readonly Dictionary<string, Dictionary<string, int>> _ordersByTable =
            new Dictionary<string, Dictionary<string, int>>(StringComparer.CurrentCultureIgnoreCase);
        private string _saveRoot = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "KitchenOrders");
        public ThucHanh1()
        {
            InitializeComponent();

            // Khởi tạo giao diện & sự kiện
            this.Load += ThucHanh1_Load;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        // ====== Helpers ======
        private string CurrentTable => cboChonBan.SelectedItem?.ToString() ?? "";

        private void EnsureCurrentTable()
        {
            if (string.IsNullOrWhiteSpace(CurrentTable))
                throw new InvalidOperationException("Vui lòng chọn bàn trước khi gọi món.");

            if (!_ordersByTable.ContainsKey(CurrentTable))
                _ordersByTable[CurrentTable] = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
        }

        private void AddItem(string itemName, int qty = 1)
        {
            EnsureCurrentTable();
            var bucket = _ordersByTable[CurrentTable];
            if (!bucket.ContainsKey(itemName)) bucket[itemName] = 0;
            bucket[itemName] += qty;
            RefreshGrid();
        }

        private void DecreaseOrRemove(string itemName, int qty = 1)
        {
            EnsureCurrentTable();
            var bucket = _ordersByTable[CurrentTable];
            if (!bucket.ContainsKey(itemName)) return;
            bucket[itemName] -= qty;
            if (bucket[itemName] <= 0) bucket.Remove(itemName);
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Món",
                    DataPropertyName = "Item",
                    Width = 260
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Số lượng",
                    DataPropertyName = "Qty",
                    Width = 100
                });
            }

            var rows = new List<Row>();
            if (!string.IsNullOrWhiteSpace(CurrentTable) && _ordersByTable.ContainsKey(CurrentTable))
            {
                rows = _ordersByTable[CurrentTable]
                    .Select(kv => new Row { Item = kv.Key, Qty = kv.Value })
                    .OrderBy(r => r.Item)
                    .ToList();
            }
            dataGridView1.DataSource = rows;
        }

        private class Row
        {
            public string Item { get; set; } = "";
            public int Qty { get; set; }
        }

        // ====== Form events ======
        private void ThucHanh1_Load(object sender, EventArgs e)
        {
            cboChonBan.Items.Clear();
            for (int i = 1; i <= 10; i++) cboChonBan.Items.Add($"Bàn {i}");
            if (cboChonBan.Items.Count > 0) cboChonBan.SelectedIndex = 0;
            dataGridView1.Font = new Font("Segoe UI", 12f);
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            RefreshGrid();
        }

        private void cboChonBan_SelectedIndexChanged(object sender, EventArgs e) => RefreshGrid();

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridView1.Rows[e.RowIndex].DataBoundItem as Row;
            if (row != null) DecreaseOrRemove(row.Item, 1);
        }

        // ====== Button món ăn ======
        private void btnCCT_Click(object sender, EventArgs e) => AddItem("Cơm chiên trứng");
        private void btnBMOL_Click(object sender, EventArgs e) => AddItem("Bánh mì ốp la");
        private void btnCoca_Click(object sender, EventArgs e) => AddItem("Coca");
        private void btnLipton_Click(object sender, EventArgs e) => AddItem("Lipton");

        private void btnORM_Click(object sender, EventArgs e) => AddItem("Ốc rang muối");
        private void btnKTC_Click(object sender, EventArgs e) => AddItem("Khoai tây chiên");
        private void btn7up_Click(object sender, EventArgs e) => AddItem("7up");
        private void btnCam_Click(object sender, EventArgs e) => AddItem("Cam");

        private void btnMXHS_Click(object sender, EventArgs e) => AddItem("Mỳ xào hải sản");
        private void btnCVC_Click(object sender, EventArgs e) => AddItem("Cá viên chiên");
        private void btnPepsi_Click(object sender, EventArgs e) => AddItem("Pepsi");
        private void btnCafe_Click(object sender, EventArgs e) => AddItem("Cafe");

        private void btnBBN_Click(object sender, EventArgs e) => AddItem("Burger bò nướng");
        private void btnDGR_Click(object sender, EventArgs e) => AddItem("Đùi gà rán");
        private void btnBBH_Click(object sender, EventArgs e) => AddItem("Bún bò Huế");

        // ====== Xóa / Order ======
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                EnsureCurrentTable();
                var bucket = _ordersByTable[CurrentTable];
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Xóa dòng được chọn
                    var row = dataGridView1.SelectedRows[0].DataBoundItem as Row;
                    if (row != null && bucket.ContainsKey(row.Item))
                    {
                        bucket.Remove(row.Item);
                        RefreshGrid();
                    }
                }
                else
                {
                    if (bucket.Count > 0 &&
                        MessageBox.Show($"Xóa toàn bộ món của {CurrentTable}?", "Xác nhận",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bucket.Clear();
                        RefreshGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void WriteOrderToFileAt(string fullPath)
        {
            EnsureCurrentTable();
            var bucket = _ordersByTable[CurrentTable];
            if (bucket.Count == 0)
            {
                MessageBox.Show("Bàn hiện chưa có món.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sw = new StreamWriter(fullPath, false, Encoding.UTF8))
            {
                sw.WriteLine($"=== ORDER {CurrentTable} ===");
                sw.WriteLine($"Thời gian: {DateTime.Now:HH:mm:ss dd/MM/yyyy}");
                sw.WriteLine("-----------------------------");
                foreach (var kv in bucket)
                    sw.WriteLine($"{kv.Key} x {kv.Value}");
                sw.WriteLine("-----------------------------");
                sw.WriteLine("Gửi bếp.");
            }

            MessageBox.Show($"Đã ghi order của {CurrentTable}:\n{fullPath}",
                "Đã gửi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                EnsureCurrentTable();

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Title = "Chọn nơi lưu Order";
                    sfd.Filter = "Text file (*.txt)|*.txt";
                    sfd.InitialDirectory = Directory.Exists(_saveRoot)
                        ? _saveRoot
                        : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    sfd.FileName = $"{CurrentTable}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        
                        var dir = Path.GetDirectoryName(sfd.FileName);
                        if (!string.IsNullOrEmpty(dir)) _saveRoot = dir;

                        WriteOrderToFileAt(sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể ghi order: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void label1_Click(object sender, EventArgs e) {  }
    }
}
