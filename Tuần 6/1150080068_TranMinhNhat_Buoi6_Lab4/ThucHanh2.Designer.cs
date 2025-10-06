namespace _1150080068_TranMinhNhat_Buoi6_Lab4
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
            this.btnSLSV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSLSV
            // 
            this.btnSLSV.Location = new System.Drawing.Point(182, 155);
            this.btnSLSV.Name = "btnSLSV";
            this.btnSLSV.Size = new System.Drawing.Size(173, 99);
            this.btnSLSV.TabIndex = 0;
            this.btnSLSV.Text = "Số lượng sinh viên";
            this.btnSLSV.UseVisualStyleBackColor = true;
            this.btnSLSV.Click += new System.EventHandler(this.btnSLSV_Click);
            // 
            // ThucHanh2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 446);
            this.Controls.Add(this.btnSLSV);
            this.Name = "ThucHanh2";
            this.Text = "ThucHanh2";
            this.Load += new System.EventHandler(this.ThucHanh2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSLSV;
    }
}