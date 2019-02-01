namespace EventViewerViewer
{
    partial class Fillter
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
            this.SourceCB = new System.Windows.Forms.ComboBox();
            this.ONButtum = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PCCB = new System.Windows.Forms.Label();
            this.UCB = new System.Windows.Forms.ComboBox();
            this.CategoryCB = new System.Windows.Forms.ComboBox();
            this.DateTo = new System.Windows.Forms.DateTimePicker();
            this.DateFrom = new System.Windows.Forms.DateTimePicker();
            this.EventName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SourceEX = new System.Windows.Forms.CheckBox();
            this.UserEX = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PCName = new System.Windows.Forms.TextBox();
            this.PCEX = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckSuc = new System.Windows.Forms.CheckBox();
            this.CheckFail = new System.Windows.Forms.CheckBox();
            this.CheckWar = new System.Windows.Forms.CheckBox();
            this.CheckErr = new System.Windows.Forms.CheckBox();
            this.CheckInfo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source";
            // 
            // SourceCB
            // 
            this.SourceCB.FormattingEnabled = true;
            this.SourceCB.Location = new System.Drawing.Point(186, 27);
            this.SourceCB.Name = "SourceCB";
            this.SourceCB.Size = new System.Drawing.Size(151, 20);
            this.SourceCB.TabIndex = 1;
            // 
            // ONButtum
            // 
            this.ONButtum.Location = new System.Drawing.Point(210, 269);
            this.ONButtum.Name = "ONButtum";
            this.ONButtum.Size = new System.Drawing.Size(75, 23);
            this.ONButtum.TabIndex = 2;
            this.ONButtum.Text = "OK";
            this.ONButtum.UseVisualStyleBackColor = true;
            this.ONButtum.Click += new System.EventHandler(this.ONButtum_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(300, 269);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "キャンセル";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "User";
            // 
            // PCCB
            // 
            this.PCCB.AutoSize = true;
            this.PCCB.Location = new System.Drawing.Point(12, 146);
            this.PCCB.Name = "PCCB";
            this.PCCB.Size = new System.Drawing.Size(81, 12);
            this.PCCB.TabIndex = 7;
            this.PCCB.Text = "コンピューター名:";
            // 
            // UCB
            // 
            this.UCB.FormattingEnabled = true;
            this.UCB.Location = new System.Drawing.Point(186, 114);
            this.UCB.Name = "UCB";
            this.UCB.Size = new System.Drawing.Size(151, 20);
            this.UCB.TabIndex = 9;
            // 
            // CategoryCB
            // 
            this.CategoryCB.FormattingEnabled = true;
            this.CategoryCB.Location = new System.Drawing.Point(186, 72);
            this.CategoryCB.Name = "CategoryCB";
            this.CategoryCB.Size = new System.Drawing.Size(151, 20);
            this.CategoryCB.TabIndex = 10;
            // 
            // DateTo
            // 
            this.DateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTo.Location = new System.Drawing.Point(210, 244);
            this.DateTo.Name = "DateTo";
            this.DateTo.Size = new System.Drawing.Size(104, 19);
            this.DateTo.TabIndex = 11;
            // 
            // DateFrom
            // 
            this.DateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateFrom.Location = new System.Drawing.Point(76, 244);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Size = new System.Drawing.Size(102, 19);
            this.DateFrom.TabIndex = 12;
            // 
            // EventName
            // 
            this.EventName.Location = new System.Drawing.Point(12, 206);
            this.EventName.Name = "EventName";
            this.EventName.Size = new System.Drawing.Size(363, 19);
            this.EventName.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "イベントID:";
            // 
            // SourceEX
            // 
            this.SourceEX.AutoSize = true;
            this.SourceEX.Location = new System.Drawing.Point(343, 29);
            this.SourceEX.Name = "SourceEX";
            this.SourceEX.Size = new System.Drawing.Size(64, 16);
            this.SourceEX.TabIndex = 15;
            this.SourceEX.Text = "Exclude";
            this.SourceEX.UseVisualStyleBackColor = true;
            // 
            // UserEX
            // 
            this.UserEX.AutoSize = true;
            this.UserEX.Location = new System.Drawing.Point(343, 116);
            this.UserEX.Name = "UserEX";
            this.UserEX.Size = new System.Drawing.Size(64, 16);
            this.UserEX.TabIndex = 16;
            this.UserEX.Text = "Exclude";
            this.UserEX.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "DAY from:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "To:";
            // 
            // PCName
            // 
            this.PCName.Location = new System.Drawing.Point(12, 161);
            this.PCName.Name = "PCName";
            this.PCName.Size = new System.Drawing.Size(325, 19);
            this.PCName.TabIndex = 19;
            // 
            // PCEX
            // 
            this.PCEX.AutoSize = true;
            this.PCEX.Location = new System.Drawing.Point(343, 163);
            this.PCEX.Name = "PCEX";
            this.PCEX.Size = new System.Drawing.Size(64, 16);
            this.PCEX.TabIndex = 20;
            this.PCEX.Text = "Exclude";
            this.PCEX.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CheckSuc);
            this.groupBox1.Controls.Add(this.CheckFail);
            this.groupBox1.Controls.Add(this.CheckWar);
            this.groupBox1.Controls.Add(this.CheckErr);
            this.groupBox1.Controls.Add(this.CheckInfo);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 131);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Event Types";
            // 
            // CheckSuc
            // 
            this.CheckSuc.AutoSize = true;
            this.CheckSuc.Location = new System.Drawing.Point(6, 106);
            this.CheckSuc.Name = "CheckSuc";
            this.CheckSuc.Size = new System.Drawing.Size(94, 16);
            this.CheckSuc.TabIndex = 27;
            this.CheckSuc.Text = "SuccessAudit";
            this.CheckSuc.UseVisualStyleBackColor = true;
            // 
            // CheckFail
            // 
            this.CheckFail.AutoSize = true;
            this.CheckFail.Location = new System.Drawing.Point(6, 84);
            this.CheckFail.Name = "CheckFail";
            this.CheckFail.Size = new System.Drawing.Size(86, 16);
            this.CheckFail.TabIndex = 26;
            this.CheckFail.Text = "FailureAudit";
            this.CheckFail.UseVisualStyleBackColor = true;
            // 
            // CheckWar
            // 
            this.CheckWar.AutoSize = true;
            this.CheckWar.Location = new System.Drawing.Point(6, 62);
            this.CheckWar.Name = "CheckWar";
            this.CheckWar.Size = new System.Drawing.Size(64, 16);
            this.CheckWar.TabIndex = 25;
            this.CheckWar.Text = "Warning";
            this.CheckWar.UseVisualStyleBackColor = true;
            // 
            // CheckErr
            // 
            this.CheckErr.AutoSize = true;
            this.CheckErr.Location = new System.Drawing.Point(6, 40);
            this.CheckErr.Name = "CheckErr";
            this.CheckErr.Size = new System.Drawing.Size(49, 16);
            this.CheckErr.TabIndex = 24;
            this.CheckErr.Text = "Error";
            this.CheckErr.UseVisualStyleBackColor = true;
            // 
            // CheckInfo
            // 
            this.CheckInfo.AutoSize = true;
            this.CheckInfo.Location = new System.Drawing.Point(6, 18);
            this.CheckInfo.Name = "CheckInfo";
            this.CheckInfo.Size = new System.Drawing.Size(81, 16);
            this.CheckInfo.TabIndex = 23;
            this.CheckInfo.Text = "Information";
            this.CheckInfo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(312, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "(入力例：単数、1000,1001 もしくは1000~1001を入力してください)";
            // 
            // Fillter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 304);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PCEX);
            this.Controls.Add(this.PCName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.UserEX);
            this.Controls.Add(this.SourceEX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EventName);
            this.Controls.Add(this.DateFrom);
            this.Controls.Add(this.DateTo);
            this.Controls.Add(this.CategoryCB);
            this.Controls.Add(this.UCB);
            this.Controls.Add(this.PCCB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.ONButtum);
            this.Controls.Add(this.SourceCB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Fillter";
            this.Text = "フィルター";
            this.Load += new System.EventHandler(this.Fillter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SourceCB;
        private System.Windows.Forms.Button ONButtum;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PCCB;
        private System.Windows.Forms.ComboBox UCB;
        private System.Windows.Forms.ComboBox CategoryCB;
        private System.Windows.Forms.DateTimePicker DateTo;
        private System.Windows.Forms.DateTimePicker DateFrom;
        private System.Windows.Forms.TextBox EventName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox SourceEX;
        private System.Windows.Forms.CheckBox UserEX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PCName;
        private System.Windows.Forms.CheckBox PCEX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CheckSuc;
        private System.Windows.Forms.CheckBox CheckFail;
        private System.Windows.Forms.CheckBox CheckWar;
        private System.Windows.Forms.CheckBox CheckErr;
        private System.Windows.Forms.CheckBox CheckInfo;
        private System.Windows.Forms.Label label4;
    }
}