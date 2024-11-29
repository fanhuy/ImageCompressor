namespace VssImageCompress__VIC_
{
    partial class frm_compress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_compress));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ck_file = new System.Windows.Forms.CheckBox();
            this.txt_imgsize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ck_folder = new System.Windows.Forms.CheckBox();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.btn_chon = new System.Windows.Forms.Button();
            this.txt_source = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_trangthai = new System.Windows.Forms.Label();
            this.txt_destination = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_compress = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gb2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ck_file);
            this.groupBox1.Controls.Add(this.txt_imgsize);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ck_folder);
            this.groupBox1.Location = new System.Drawing.Point(120, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tùy chọn nén ảnh";
            // 
            // ck_file
            // 
            this.ck_file.AutoSize = true;
            this.ck_file.Checked = true;
            this.ck_file.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_file.Location = new System.Drawing.Point(20, 19);
            this.ck_file.Name = "ck_file";
            this.ck_file.Size = new System.Drawing.Size(119, 17);
            this.ck_file.TabIndex = 37;
            this.ck_file.Text = "Nén ảnh/nhiều ảnh";
            this.ck_file.UseVisualStyleBackColor = true;
            this.ck_file.CheckedChanged += new System.EventHandler(this.ck_file_CheckedChanged);
            // 
            // txt_imgsize
            // 
            this.txt_imgsize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_imgsize.Location = new System.Drawing.Point(204, 43);
            this.txt_imgsize.MaxLength = 4;
            this.txt_imgsize.Name = "txt_imgsize";
            this.txt_imgsize.Size = new System.Drawing.Size(41, 20);
            this.txt_imgsize.TabIndex = 34;
            this.txt_imgsize.Text = "95";
            this.txt_imgsize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_imgsize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_imgsize_KeyDown);
            this.txt_imgsize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_imgsize_KeyPress);
            this.txt_imgsize.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_imgsize_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Dung lượng sau khi nén nhỏ hơn:";
            // 
            // ck_folder
            // 
            this.ck_folder.AutoSize = true;
            this.ck_folder.Location = new System.Drawing.Point(204, 20);
            this.ck_folder.Name = "ck_folder";
            this.ck_folder.Size = new System.Drawing.Size(174, 17);
            this.ck_folder.TabIndex = 32;
            this.ck_folder.Text = "Nén toàn bộ ảnh trong thư mục";
            this.ck_folder.UseVisualStyleBackColor = true;
            this.ck_folder.CheckedChanged += new System.EventHandler(this.ck_folder_CheckedChanged);
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.btn_chon);
            this.gb2.Controls.Add(this.txt_source);
            this.gb2.Controls.Add(this.label1);
            this.gb2.Controls.Add(this.lbl_trangthai);
            this.gb2.Controls.Add(this.txt_destination);
            this.gb2.Controls.Add(this.progressBar1);
            this.gb2.Controls.Add(this.label2);
            this.gb2.Location = new System.Drawing.Point(12, 89);
            this.gb2.MaximumSize = new System.Drawing.Size(503, 113);
            this.gb2.MinimumSize = new System.Drawing.Size(503, 81);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(503, 113);
            this.gb2.TabIndex = 37;
            this.gb2.TabStop = false;
            this.gb2.Text = "Quảng Trị Vss";
            // 
            // btn_chon
            // 
            this.btn_chon.Location = new System.Drawing.Point(397, 22);
            this.btn_chon.Name = "btn_chon";
            this.btn_chon.Size = new System.Drawing.Size(89, 48);
            this.btn_chon.TabIndex = 38;
            this.btn_chon.Text = "Chọn thư mục lưu kết quả";
            this.btn_chon.UseVisualStyleBackColor = true;
            this.btn_chon.Click += new System.EventHandler(this.btn_chon_Click);
            // 
            // txt_source
            // 
            this.txt_source.BackColor = System.Drawing.SystemColors.Window;
            this.txt_source.Location = new System.Drawing.Point(117, 22);
            this.txt_source.Name = "txt_source";
            this.txt_source.ReadOnly = true;
            this.txt_source.Size = new System.Drawing.Size(258, 20);
            this.txt_source.TabIndex = 32;
            this.txt_source.Click += new System.EventHandler(this.txt_source_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Thư mục chứa ảnh:";
            // 
            // lbl_trangthai
            // 
            this.lbl_trangthai.AutoSize = true;
            this.lbl_trangthai.Location = new System.Drawing.Point(29, 74);
            this.lbl_trangthai.Name = "lbl_trangthai";
            this.lbl_trangthai.Size = new System.Drawing.Size(82, 13);
            this.lbl_trangthai.TabIndex = 37;
            this.lbl_trangthai.Text = "Trạng thái xử lý:";
            this.lbl_trangthai.Visible = false;
            // 
            // txt_destination
            // 
            this.txt_destination.BackColor = System.Drawing.SystemColors.Window;
            this.txt_destination.Location = new System.Drawing.Point(117, 48);
            this.txt_destination.Name = "txt_destination";
            this.txt_destination.ReadOnly = true;
            this.txt_destination.Size = new System.Drawing.Size(258, 20);
            this.txt_destination.TabIndex = 34;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(117, 74);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(258, 20);
            this.progressBar1.TabIndex = 36;
            this.progressBar1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Thưc mục kết quả:";
            // 
            // btn_compress
            // 
            this.btn_compress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_compress.Image = ((System.Drawing.Image)(resources.GetObject("btn_compress.Image")));
            this.btn_compress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_compress.Location = new System.Drawing.Point(8, 20);
            this.btn_compress.Name = "btn_compress";
            this.btn_compress.Padding = new System.Windows.Forms.Padding(2);
            this.btn_compress.Size = new System.Drawing.Size(106, 52);
            this.btn_compress.TabIndex = 36;
            this.btn_compress.Text = "Nén ảnh";
            this.btn_compress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_compress.UseVisualStyleBackColor = true;
            this.btn_compress.Click += new System.EventHandler(this.btn_compress_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(246, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "KB";
            // 
            // frm_compress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 215);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.btn_compress);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(544, 254);
            this.MinimumSize = new System.Drawing.Size(544, 214);
            this.Name = "frm_compress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Công cụ nén ảnh";
            this.Load += new System.EventHandler(this.frm_compress_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_imgsize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ck_folder;
        private System.Windows.Forms.Button btn_compress;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.TextBox txt_source;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_trangthai;
        private System.Windows.Forms.TextBox txt_destination;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ck_file;
        private System.Windows.Forms.Button btn_chon;
        private System.Windows.Forms.Label label4;
    }
}

