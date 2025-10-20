namespace _1150080068_TranMinhNhat_Buoi8_Lab6
{
    partial class ThucHanh3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTenNXB = new System.Windows.Forms.TextBox();
            this.txtMaNXB = new System.Windows.Forms.TextBox();
            this.btnSuaNXB = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstvDanhSachNXB = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDiaChi);
            this.groupBox2.Controls.Add(this.txtTenNXB);
            this.groupBox2.Controls.Add(this.txtMaNXB);
            this.groupBox2.Controls.Add(this.btnSuaNXB);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(719, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 375);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin nhập liệu";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(81, 185);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(208, 26);
            this.txtDiaChi.TabIndex = 6;
            this.txtDiaChi.TextChanged += new System.EventHandler(this.txtDiaChi_TextChanged);
            // 
            // txtTenNXB
            // 
            this.txtTenNXB.Location = new System.Drawing.Point(81, 113);
            this.txtTenNXB.Name = "txtTenNXB";
            this.txtTenNXB.Size = new System.Drawing.Size(208, 26);
            this.txtTenNXB.TabIndex = 5;
            this.txtTenNXB.TextChanged += new System.EventHandler(this.txtTenNXB_TextChanged);
            // 
            // txtMaNXB
            // 
            this.txtMaNXB.Location = new System.Drawing.Point(81, 48);
            this.txtMaNXB.Name = "txtMaNXB";
            this.txtMaNXB.Size = new System.Drawing.Size(208, 26);
            this.txtMaNXB.TabIndex = 4;
            this.txtMaNXB.TextChanged += new System.EventHandler(this.txtMaNXB_TextChanged);
            // 
            // btnSuaNXB
            // 
            this.btnSuaNXB.BackColor = System.Drawing.Color.Lime;
            this.btnSuaNXB.Location = new System.Drawing.Point(10, 278);
            this.btnSuaNXB.Name = "btnSuaNXB";
            this.btnSuaNXB.Size = new System.Drawing.Size(279, 69);
            this.btnSuaNXB.TabIndex = 3;
            this.btnSuaNXB.Text = "Cập nhật thông tin";
            this.btnSuaNXB.UseVisualStyleBackColor = false;
            this.btnSuaNXB.Click += new System.EventHandler(this.btnSuaNXB_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên NXB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã NXB";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstvDanhSachNXB);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(707, 386);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách nhà xuất bản";
            // 
            // lstvDanhSachNXB
            // 
            this.lstvDanhSachNXB.HideSelection = false;
            this.lstvDanhSachNXB.Location = new System.Drawing.Point(6, 25);
            this.lstvDanhSachNXB.Name = "lstvDanhSachNXB";
            this.lstvDanhSachNXB.Size = new System.Drawing.Size(695, 355);
            this.lstvDanhSachNXB.TabIndex = 1;
            this.lstvDanhSachNXB.UseCompatibleStateImageBehavior = false;
            this.lstvDanhSachNXB.SelectedIndexChanged += new System.EventHandler(this.lstvDanhSachNXB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(295, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cập nhật dữ liệu";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ThucHanh3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 455);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "ThucHanh3";
            this.Text = "ThucHanh3";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTenNXB;
        private System.Windows.Forms.TextBox txtMaNXB;
        private System.Windows.Forms.Button btnSuaNXB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstvDanhSachNXB;
        private System.Windows.Forms.Label label1;
    }
}