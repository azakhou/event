namespace EventViewerViewer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_play = new System.Windows.Forms.Button();
            this.CB_EventLevel = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Btn_Fill = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Lbl_Rowcount = new System.Windows.Forms.Label();
            this.XMLBtn = new System.Windows.Forms.Button();
            this.outbtn = new System.Windows.Forms.Button();
            this.Removebtn = new System.Windows.Forms.Button();
            this.CB_FName = new System.Windows.Forms.ComboBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.dgView = new DataGridViewEx();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_play
            // 
            this.btn_play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_play.Location = new System.Drawing.Point(556, 469);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(75, 23);
            this.btn_play.TabIndex = 1;
            this.btn_play.Text = "実行";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // CB_EventLevel
            // 
            this.CB_EventLevel.FormattingEnabled = true;
            this.CB_EventLevel.Location = new System.Drawing.Point(214, 12);
            this.CB_EventLevel.Name = "CB_EventLevel";
            this.CB_EventLevel.Size = new System.Drawing.Size(135, 20);
            this.CB_EventLevel.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Location = new System.Drawing.Point(509, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(122, 19);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 20);
            this.comboBox1.TabIndex = 7;
            // 
            // Btn_Fill
            // 
            this.Btn_Fill.Location = new System.Drawing.Point(387, 12);
            this.Btn_Fill.Name = "Btn_Fill";
            this.Btn_Fill.Size = new System.Drawing.Size(75, 23);
            this.Btn_Fill.TabIndex = 8;
            this.Btn_Fill.Text = "フィルター";
            this.Btn_Fill.UseVisualStyleBackColor = true;
            this.Btn_Fill.Click += new System.EventHandler(this.Btn_Fill_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 479);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "行数：";
            // 
            // Lbl_Rowcount
            // 
            this.Lbl_Rowcount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lbl_Rowcount.AutoSize = true;
            this.Lbl_Rowcount.Location = new System.Drawing.Point(55, 479);
            this.Lbl_Rowcount.Name = "Lbl_Rowcount";
            this.Lbl_Rowcount.Size = new System.Drawing.Size(0, 12);
            this.Lbl_Rowcount.TabIndex = 10;
            // 
            // XMLBtn
            // 
            this.XMLBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.XMLBtn.Location = new System.Drawing.Point(475, 469);
            this.XMLBtn.Name = "XMLBtn";
            this.XMLBtn.Size = new System.Drawing.Size(75, 23);
            this.XMLBtn.TabIndex = 11;
            this.XMLBtn.Text = "データ除外";
            this.XMLBtn.UseVisualStyleBackColor = true;
            this.XMLBtn.Click += new System.EventHandler(this.XMLBtn_Click);
            // 
            // outbtn
            // 
            this.outbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.outbtn.Location = new System.Drawing.Point(313, 469);
            this.outbtn.Name = "outbtn";
            this.outbtn.Size = new System.Drawing.Size(75, 23);
            this.outbtn.TabIndex = 12;
            this.outbtn.Text = "除外登録";
            this.outbtn.UseVisualStyleBackColor = true;
            this.outbtn.Click += new System.EventHandler(this.outbtn_Click);
            // 
            // Removebtn
            // 
            this.Removebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Removebtn.Location = new System.Drawing.Point(394, 469);
            this.Removebtn.Name = "Removebtn";
            this.Removebtn.Size = new System.Drawing.Size(75, 23);
            this.Removebtn.TabIndex = 13;
            this.Removebtn.Text = "除外削除";
            this.Removebtn.UseVisualStyleBackColor = true;
            this.Removebtn.Click += new System.EventHandler(this.Removebtn_Click);
            // 
            // CB_FName
            // 
            this.CB_FName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CB_FName.FormattingEnabled = true;
            this.CB_FName.Location = new System.Drawing.Point(172, 470);
            this.CB_FName.Name = "CB_FName";
            this.CB_FName.Size = new System.Drawing.Size(135, 20);
            this.CB_FName.TabIndex = 14;
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.Location = new System.Drawing.Point(114, 469);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(52, 23);
            this.btn_add.TabIndex = 15;
            this.btn_add.Text = "追加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dgView
            // 
            this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgView.Location = new System.Drawing.Point(12, 54);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.RowTemplate.Height = 21;
            this.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgView.Size = new System.Drawing.Size(619, 409);
            this.dgView.TabIndex = 16;
            this.dgView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgView_CellContentDoubleClick);
            this.dgView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgView_CellFormatting);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 504);
            this.Controls.Add(this.dgView);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.CB_FName);
            this.Controls.Add(this.Removebtn);
            this.Controls.Add(this.outbtn);
            this.Controls.Add(this.XMLBtn);
            this.Controls.Add(this.Lbl_Rowcount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Fill);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.CB_EventLevel);
            this.Controls.Add(this.btn_play);
            this.Name = "Form1";
            this.Text = "イベントビューア";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.ComboBox CB_EventLevel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Btn_Fill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lbl_Rowcount;
        private System.Windows.Forms.Button XMLBtn;
        private System.Windows.Forms.Button outbtn;
        private System.Windows.Forms.Button Removebtn;
        private System.Windows.Forms.ComboBox CB_FName;
        private System.Windows.Forms.Button btn_add;
        private DataGridViewEx dgView;
    }
}

