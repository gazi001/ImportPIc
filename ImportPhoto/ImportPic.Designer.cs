namespace ImportPhoto
{
    partial class ImportPic
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnChoosePhotoes = new System.Windows.Forms.Button();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelPhotoes = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(28, 59);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(401, 268);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnSavePath
            // 
            this.btnSavePath.Location = new System.Drawing.Point(446, 30);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(75, 23);
            this.btnSavePath.TabIndex = 1;
            this.btnSavePath.Text = "存储目录";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(401, 21);
            this.textBox1.TabIndex = 2;
            // 
            // btnChoosePhotoes
            // 
            this.btnChoosePhotoes.Location = new System.Drawing.Point(446, 59);
            this.btnChoosePhotoes.Name = "btnChoosePhotoes";
            this.btnChoosePhotoes.Size = new System.Drawing.Size(75, 23);
            this.btnChoosePhotoes.TabIndex = 3;
            this.btnChoosePhotoes.Text = "添加文件";
            this.btnChoosePhotoes.UseVisualStyleBackColor = true;
            this.btnChoosePhotoes.Click += new System.EventHandler(this.btnChoosePhotoes_Click);
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Location = new System.Drawing.Point(446, 88);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(75, 23);
            this.btnUploadFile.TabIndex = 4;
            this.btnUploadFile.Text = "上传";
            this.btnUploadFile.UseVisualStyleBackColor = true;
            this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 5;
            // 
            // btnDelPhotoes
            // 
            this.btnDelPhotoes.Location = new System.Drawing.Point(446, 117);
            this.btnDelPhotoes.Name = "btnDelPhotoes";
            this.btnDelPhotoes.Size = new System.Drawing.Size(75, 23);
            this.btnDelPhotoes.TabIndex = 7;
            this.btnDelPhotoes.Text = "移除文件";
            this.btnDelPhotoes.UseVisualStyleBackColor = true;
            this.btnDelPhotoes.Click += new System.EventHandler(this.btnDelPhotoes_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(446, 147);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 8;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // ImportPic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 412);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnDelPhotoes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUploadFile);
            this.Controls.Add(this.btnChoosePhotoes);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSavePath);
            this.Controls.Add(this.listView1);
            this.Name = "ImportPic";
            this.Text = "哈妮OA照片备份导入";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnChoosePhotoes;
        private System.Windows.Forms.Button btnUploadFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelPhotoes;
        private System.Windows.Forms.Button btnSelectAll;
    }
}