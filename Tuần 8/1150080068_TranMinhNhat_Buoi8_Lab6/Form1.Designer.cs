namespace _1150080068_TranMinhNhat_Buoi8_Lab6
{
    partial class Form1
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
            this.lstvDanhSach = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(162, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hiển thị chi tiết NXB";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lstvDanhSach
            // 
            this.lstvDanhSach.HideSelection = false;
            this.lstvDanhSach.Location = new System.Drawing.Point(12, 79);
            this.lstvDanhSach.Name = "lstvDanhSach";
            this.lstvDanhSach.Size = new System.Drawing.Size(679, 472);
            this.lstvDanhSach.TabIndex = 1;
            this.lstvDanhSach.UseCompatibleStateImageBehavior = false;
            this.lstvDanhSach.SelectedIndexChanged += new System.EventHandler(this.lstvDanhSach_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 563);
            this.Controls.Add(this.lstvDanhSach);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstvDanhSach;
    }
}

