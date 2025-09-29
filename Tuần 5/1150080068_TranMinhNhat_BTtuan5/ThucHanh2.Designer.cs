namespace _1150080068_TranMinhNhat_BTtuan5
{
    partial class ThucHanh2
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudBocRang = new System.Windows.Forms.NumericUpDown();
            this.nudBeRang = new System.Windows.Forms.NumericUpDown();
            this.nudHanRang = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkBocRang = new System.Windows.Forms.CheckBox();
            this.chkBeRang = new System.Windows.Forms.CheckBox();
            this.chkHanRang = new System.Windows.Forms.CheckBox();
            this.chkTayTrangR = new System.Windows.Forms.CheckBox();
            this.chkLayCaoR = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTinhTien = new System.Windows.Forms.Button();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBocRang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBeRang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHanRang)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Lime;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(-1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(801, 91);
            this.label1.TabIndex = 0;
            this.label1.Text = "PHÒNG KHÁM ĐA KHOA HẢI ÂU";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseWaitCursor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.txtTenKH);
            this.groupBox1.Location = new System.Drawing.Point(0, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tên Khách Hàng";
            // 
            // txtTenKH
            // 
            this.txtTenKH.BackColor = System.Drawing.Color.White;
            this.txtTenKH.Location = new System.Drawing.Point(197, 39);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(396, 26);
            this.txtTenKH.TabIndex = 0;
            this.txtTenKH.TextChanged += new System.EventHandler(this.txtTenKH_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudBocRang);
            this.groupBox2.Controls.Add(this.nudBeRang);
            this.groupBox2.Controls.Add(this.nudHanRang);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.chkBocRang);
            this.groupBox2.Controls.Add(this.chkBeRang);
            this.groupBox2.Controls.Add(this.chkHanRang);
            this.groupBox2.Controls.Add(this.chkTayTrangR);
            this.groupBox2.Controls.Add(this.chkLayCaoR);
            this.groupBox2.Location = new System.Drawing.Point(0, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 218);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dịch vụ tại phòng khám";
            // 
            // nudBocRang
            // 
            this.nudBocRang.Location = new System.Drawing.Point(591, 159);
            this.nudBocRang.Name = "nudBocRang";
            this.nudBocRang.Size = new System.Drawing.Size(56, 26);
            this.nudBocRang.TabIndex = 12;
            this.nudBocRang.ValueChanged += new System.EventHandler(this.nudBocRang_ValueChanged);
            // 
            // nudBeRang
            // 
            this.nudBeRang.Location = new System.Drawing.Point(591, 129);
            this.nudBeRang.Name = "nudBeRang";
            this.nudBeRang.Size = new System.Drawing.Size(56, 26);
            this.nudBeRang.TabIndex = 11;
            this.nudBeRang.ValueChanged += new System.EventHandler(this.nudBeRang_ValueChanged);
            // 
            // nudHanRang
            // 
            this.nudHanRang.Location = new System.Drawing.Point(591, 97);
            this.nudHanRang.Name = "nudHanRang";
            this.nudHanRang.Size = new System.Drawing.Size(56, 26);
            this.nudHanRang.TabIndex = 10;
            this.nudHanRang.ValueChanged += new System.EventHandler(this.nudHanRang_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(427, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "1.000.000đ/1 răng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(427, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "10.000đ/1 răng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(427, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "100.000đ/1 răng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "100.000đ/2 hàm";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "50.000đ/2 hàm";
            // 
            // chkBocRang
            // 
            this.chkBocRang.AutoSize = true;
            this.chkBocRang.Location = new System.Drawing.Point(197, 158);
            this.chkBocRang.Name = "chkBocRang";
            this.chkBocRang.Size = new System.Drawing.Size(99, 24);
            this.chkBocRang.TabIndex = 4;
            this.chkBocRang.Text = "Bọc răng";
            this.chkBocRang.UseVisualStyleBackColor = true;
            this.chkBocRang.CheckedChanged += new System.EventHandler(this.chkBocRang_CheckedChanged);
            // 
            // chkBeRang
            // 
            this.chkBeRang.AutoSize = true;
            this.chkBeRang.Location = new System.Drawing.Point(197, 128);
            this.chkBeRang.Name = "chkBeRang";
            this.chkBeRang.Size = new System.Drawing.Size(91, 24);
            this.chkBeRang.TabIndex = 3;
            this.chkBeRang.Text = "Bẻ răng";
            this.chkBeRang.UseVisualStyleBackColor = true;
            this.chkBeRang.CheckedChanged += new System.EventHandler(this.chkBeRang_CheckedChanged);
            // 
            // chkHanRang
            // 
            this.chkHanRang.AutoSize = true;
            this.chkHanRang.Location = new System.Drawing.Point(197, 98);
            this.chkHanRang.Name = "chkHanRang";
            this.chkHanRang.Size = new System.Drawing.Size(101, 24);
            this.chkHanRang.TabIndex = 2;
            this.chkHanRang.Text = "Hàn răng";
            this.chkHanRang.UseVisualStyleBackColor = true;
            this.chkHanRang.CheckedChanged += new System.EventHandler(this.chkHanRang_CheckedChanged);
            // 
            // chkTayTrangR
            // 
            this.chkTayTrangR.AutoSize = true;
            this.chkTayTrangR.Location = new System.Drawing.Point(197, 68);
            this.chkTayTrangR.Name = "chkTayTrangR";
            this.chkTayTrangR.Size = new System.Drawing.Size(137, 24);
            this.chkTayTrangR.TabIndex = 1;
            this.chkTayTrangR.Text = "Tẩy trắng răng";
            this.chkTayTrangR.UseVisualStyleBackColor = true;
            this.chkTayTrangR.CheckedChanged += new System.EventHandler(this.chkTayTrangR_CheckedChanged);
            // 
            // chkLayCaoR
            // 
            this.chkLayCaoR.AutoSize = true;
            this.chkLayCaoR.Location = new System.Drawing.Point(197, 38);
            this.chkLayCaoR.Name = "chkLayCaoR";
            this.chkLayCaoR.Size = new System.Drawing.Size(126, 24);
            this.chkLayCaoR.TabIndex = 0;
            this.chkLayCaoR.Text = "Lấy cao răng";
            this.chkLayCaoR.UseVisualStyleBackColor = true;
            this.chkLayCaoR.CheckedChanged += new System.EventHandler(this.chkLayCaoR_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnThoat);
            this.groupBox3.Controls.Add(this.btnTinhTien);
            this.groupBox3.Controls.Add(this.txtKetQua);
            this.groupBox3.Location = new System.Drawing.Point(0, 424);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(800, 145);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(604, 58);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(108, 40);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Location = new System.Drawing.Point(102, 58);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(108, 40);
            this.btnTinhTien.TabIndex = 2;
            this.btnTinhTien.Text = "Tính tiền";
            this.btnTinhTien.UseVisualStyleBackColor = true;
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // txtKetQua
            // 
            this.txtKetQua.Location = new System.Drawing.Point(279, 65);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(241, 26);
            this.txtKetQua.TabIndex = 1;
            this.txtKetQua.TextChanged += new System.EventHandler(this.txtKetQua_TextChanged);
            // 
            // ThucHanh2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 567);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "ThucHanh2";
            this.Text = "ThucHanh2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBocRang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBeRang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHanRang)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkBocRang;
        private System.Windows.Forms.CheckBox chkBeRang;
        private System.Windows.Forms.CheckBox chkHanRang;
        private System.Windows.Forms.CheckBox chkTayTrangR;
        private System.Windows.Forms.CheckBox chkLayCaoR;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTinhTien;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.NumericUpDown nudBocRang;
        private System.Windows.Forms.NumericUpDown nudBeRang;
        private System.Windows.Forms.NumericUpDown nudHanRang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}