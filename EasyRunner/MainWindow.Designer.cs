namespace EasyRunner
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.browse_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ip_textbox = new System.Windows.Forms.TextBox();
            this.test_btn = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.file_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tarns_btn = new System.Windows.Forms.Button();
            this.del_btn = new System.Windows.Forms.Button();
            this.run_btn = new System.Windows.Forms.Button();
            this.connect_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // browse_btn
            // 
            this.browse_btn.Location = new System.Drawing.Point(658, 99);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(112, 33);
            this.browse_btn.TabIndex = 0;
            this.browse_btn.Text = "浏览";
            this.browse_btn.UseVisualStyleBackColor = true;
            this.browse_btn.Click += new System.EventHandler(this.Button_Clicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(66, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP地址";
            // 
            // ip_textbox
            // 
            this.ip_textbox.Location = new System.Drawing.Point(156, 38);
            this.ip_textbox.Name = "ip_textbox";
            this.ip_textbox.Size = new System.Drawing.Size(473, 30);
            this.ip_textbox.TabIndex = 2;
            // 
            // test_btn
            // 
            this.test_btn.Location = new System.Drawing.Point(658, 35);
            this.test_btn.Name = "test_btn";
            this.test_btn.Size = new System.Drawing.Size(112, 33);
            this.test_btn.TabIndex = 3;
            this.test_btn.Text = "测试连接";
            this.test_btn.UseVisualStyleBackColor = true;
            this.test_btn.Click += new System.EventHandler(this.Button_Clicked);
            // 
            // file_textbox
            // 
            this.file_textbox.Location = new System.Drawing.Point(156, 98);
            this.file_textbox.Name = "file_textbox";
            this.file_textbox.ReadOnly = true;
            this.file_textbox.Size = new System.Drawing.Size(473, 30);
            this.file_textbox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(23, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "文件路径";
            // 
            // tarns_btn
            // 
            this.tarns_btn.Location = new System.Drawing.Point(269, 260);
            this.tarns_btn.Name = "tarns_btn";
            this.tarns_btn.Size = new System.Drawing.Size(120, 60);
            this.tarns_btn.TabIndex = 6;
            this.tarns_btn.Text = "上传文件";
            this.tarns_btn.UseVisualStyleBackColor = true;
            this.tarns_btn.Click += new System.EventHandler(this.Button_Clicked);
            // 
            // del_btn
            // 
            this.del_btn.Location = new System.Drawing.Point(443, 260);
            this.del_btn.Name = "del_btn";
            this.del_btn.Size = new System.Drawing.Size(120, 60);
            this.del_btn.TabIndex = 7;
            this.del_btn.Text = "删除文件";
            this.del_btn.UseVisualStyleBackColor = true;
            this.del_btn.Click += new System.EventHandler(this.Button_Clicked);
            // 
            // run_btn
            // 
            this.run_btn.Location = new System.Drawing.Point(615, 260);
            this.run_btn.Name = "run_btn";
            this.run_btn.Size = new System.Drawing.Size(120, 60);
            this.run_btn.TabIndex = 8;
            this.run_btn.Text = "运行文件";
            this.run_btn.UseVisualStyleBackColor = true;
            this.run_btn.Click += new System.EventHandler(this.Button_Clicked);
            // 
            // connect_btn
            // 
            this.connect_btn.Location = new System.Drawing.Point(103, 260);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(120, 60);
            this.connect_btn.TabIndex = 9;
            this.connect_btn.Text = "发起连接";
            this.connect_btn.UseVisualStyleBackColor = true;
            this.connect_btn.Click += new System.EventHandler(this.Button_Clicked);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.connect_btn);
            this.Controls.Add(this.run_btn);
            this.Controls.Add(this.del_btn);
            this.Controls.Add(this.tarns_btn);
            this.Controls.Add(this.file_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.test_btn);
            this.Controls.Add(this.ip_textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.browse_btn);
            this.Name = "MainWindow";
            this.Text = "EasyRunner";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browse_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ip_textbox;
        private System.Windows.Forms.Button test_btn;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox file_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button tarns_btn;
        private System.Windows.Forms.Button del_btn;
        private System.Windows.Forms.Button run_btn;
        private System.Windows.Forms.Button connect_btn;
    }
}